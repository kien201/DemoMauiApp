using Fundamentals.CustomControls;
using Fundamentals.ViewModels;
using Fundamentals.Views;
using Microsoft.Extensions.Logging;

namespace Fundamentals
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler(typeof(DatePickerNullable), typeof(Fundamentals.Platforms.Android.Renderers.DatePickerNullableRenderer));
#endif
                });

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<RefreshViewPage>();
            builder.Services.AddTransient<RefreshViewPageViewModel>();
            builder.Services.AddTransient<DemoPage>();
            builder.Services.AddTransient<DemoPageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
