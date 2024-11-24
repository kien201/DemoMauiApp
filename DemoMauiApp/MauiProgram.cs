using CommunityToolkit.Maui;
using DemoMauiApp.Services;
using DemoMauiApp.ViewModels;
using DemoMauiApp.Views;
using Microsoft.Extensions.Logging;

namespace DemoMauiApp
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

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddSingleton<DetailPage>();
            builder.Services.AddSingleton<DetailPageViewModel>();
            builder.Services.AddSingleton<WIEformPage>();
            builder.Services.AddSingleton<WIEformPageViewModel>();

            builder.Services.AddTransient<NavigationService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
