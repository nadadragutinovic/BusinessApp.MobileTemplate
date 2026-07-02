using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Features.Authentication.Models;

public sealed class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }
}