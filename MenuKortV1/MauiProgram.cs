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

            // Build forsiden der indeholder menulisten
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // Build siden der viser menukortets varer
            builder.Services.AddTransient<MenuItemPage>();
            builder.Services.AddTransient<MenuItemViewModel>();

            // Build siden der viser varens info
            builder.Services.AddTransient<ItemInfo>();
            builder.Services.AddTransient<ItemInfoViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}