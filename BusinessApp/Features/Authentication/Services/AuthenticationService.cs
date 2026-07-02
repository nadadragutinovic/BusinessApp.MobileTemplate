
namespace BusinessApp.Features.Authentication.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        public Task<bool> LoginAsync(string userName, string password)
        {
            // Ovde ćemo kasnije pozvati REST API.
            return Task.FromResult(true);
        }

        public Task LogoutAsync()
        {
            return Task.CompletedTask;
        }

        public Task<bool> IsAuthenticatedAsync()
        {
            return Task.FromResult(false);
        }
    }
}
