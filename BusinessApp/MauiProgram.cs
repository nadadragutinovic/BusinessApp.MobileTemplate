using BusinessApp.Features.Authentication.Services;
using BusinessApp.Views;
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
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            return builder.Build();
        }
    }
}
