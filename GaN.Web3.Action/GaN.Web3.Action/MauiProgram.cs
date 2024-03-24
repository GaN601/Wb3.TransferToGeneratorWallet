using GaN.Web3.Action.Rcl;
using GaN.Web3.Action.Rcl.Expand;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace GaN.Web3.Action;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); })
            .ConfigureLifecycleEvents(
                events =>
                {
#if WINDOWS
                events.AddWindows(window =>
                {
                    window.OnWindowCreated(wd => { wd.AppWindow.Resize(new Windows.Graphics.SizeInt32(1024, 900)); });
                });
#endif
                });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMasaBlazor();
        builder.Services.AddCustomDi();


#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
}