using MenuKortV1.View;

namespace MenuKortV1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Opret navigationsforbindelse/routing
            Routing.RegisterRoute(nameof(MenuItemPage), typeof(MenuItemPage));
            Routing.RegisterRoute(nameof(OrdrePage), typeof(OrdrePage));
        }
    }
}