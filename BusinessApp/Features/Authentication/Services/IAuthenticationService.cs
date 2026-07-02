namespace BusinessApp.Features.Authentication.Services;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(string userName, string password);

    Task LogoutAsync();

    Task<bool> IsAuthenticatedAsync();
}
