using CommunityToolkit.Maui;
using MenuKortV1.View;
using MenuKortV1.ViewModel;
using Microsoft.Extensions.Logging;

namespace MenuKortV1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit();

            // Register dependency injection for views
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<OrdreDetailsPage>();
            builder.Services.AddTransient<MenuItemPage>();
            builder.Services.AddTransient<OrdrePage>();

            // Register dependency injection for models
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<OrdreDetailsViewModel>();
            builder.Services.AddTransient<MenuItemViewModel>();
            builder.Services.AddTransient<OrdrePageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}