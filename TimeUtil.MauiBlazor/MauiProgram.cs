using Microsoft.AspNetCore.Components.WebView.Maui;
using TimeUtil.Components;
using TimeUtil.Shared.Interfaces;
using TimeUtil.MauiBlazor.Services;

namespace TimeUtil.MauiBlazor
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
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddTimeUtilComponents();
            builder.Services.AddScoped<IOutlookCalendarCSVParseService, OutlookCSVParseJS>();

            return builder.Build();
        }
    }
}