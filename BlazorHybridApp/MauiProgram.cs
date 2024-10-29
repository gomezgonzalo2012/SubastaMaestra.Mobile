using BlazorHybridApp.Services;
using BlazorHybridApp.Services.Auction;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHybridApp
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
            builder.Services.AddHttpClient();

            // agregado
            builder.Services.AddSingleton<IRickAndMortyService, RickAndMortyService>();
            builder.Services.AddSingleton<IAuctionService, AuctionService>();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7093") });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
