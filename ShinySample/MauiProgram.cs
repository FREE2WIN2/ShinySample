using Microsoft.Extensions.Logging;
using Shiny;
using ShinySample.Delegate;

namespace ShinySample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseShiny()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddGps<MyGpsDelegate>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<GeoLocationTrackingService>();

        builder.Logging.AddConsole();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}