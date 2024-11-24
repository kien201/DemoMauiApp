using DocumentApp.Models;
using DocumentApp.Pages;
using DocumentApp.Services;
using DocumentApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace DocumentApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterDB()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        static MauiAppBuilder RegisterDB(this MauiAppBuilder builder)
        {
            builder.Services.AddDbContext<DocumentDbContext>();
            return builder;
        }

        static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<NavigationService>();
            builder.Services.AddTransient<DocumentService>();
            return builder;
        }

        static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<DetailPageViewModel>();
            return builder;
        }

        static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetailPage>();
            return builder;
        }
    }
}
