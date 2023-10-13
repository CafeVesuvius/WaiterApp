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
            Routing.RegisterRoute(nameof(MenusPage), typeof(MenusPage));
            Routing.RegisterRoute(nameof(ActiveOrders), typeof(ActiveOrders));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        }
    }
}