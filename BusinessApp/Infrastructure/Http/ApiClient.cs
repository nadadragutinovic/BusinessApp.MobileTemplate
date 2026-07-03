using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace BusinessApp.Infrastructure.Http;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);

        await EnsureSuccess(response);

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, request);

        await EnsureSuccess(response);

        return await response.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task PutAsync<TRequest>(
        string endpoint,
        TRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync(endpoint, request);

        await EnsureSuccess(response);
    }

    public async Task DeleteAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync(endpoint);

        await EnsureSuccess(response);
    }


    private static async Task EnsureSuccess(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var message = await response.Content.ReadAsStringAsync();

        throw new ApiException(
            message,
            (int)response.StatusCode);
    }
}
