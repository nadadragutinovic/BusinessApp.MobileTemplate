using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Infrastructure.Http;

public interface IApiClient
{
    Task<T?> GetAsync<T>(string endpoint);

    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request);

    Task<TRequest> PutAsync<TRequest>(string endpoint, TRequest request);

    Task DeleteAsync(string endpoint);
}
