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
            builder.Services.AddTransient<MenuItemPage>();
            builder.Services.AddSingleton<MenusPage>();

            // Register dependency injection for models
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<MenuItemViewModel>();
            builder.Services.AddSingleton<MenusViewModel>();



#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}