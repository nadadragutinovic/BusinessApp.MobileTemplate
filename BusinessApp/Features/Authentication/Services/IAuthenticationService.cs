using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Features.Authentication.Services
{    
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string userName, string password);

        Task LogoutAsync();

        Task<bool> IsAuthenticatedAsync();
    }
}
