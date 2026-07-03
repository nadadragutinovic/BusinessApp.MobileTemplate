using BusinessApp.Features.Authentication.Services;
using BusinessApp.Features.Authentication.ViewModels;
using BusinessApp.Features.Authentication.Views;
using BusinessApp.Features.Dashboard.Views;
using BusinessApp.Infrastructure.Http;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace BusinessApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
     .UseMauiApp<App>()
     .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<DashboardPage>();
            builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7000/api/");
                client.Timeout = TimeSpan.FromSeconds(30);
            });
            return builder.Build();
        }
    }
}
