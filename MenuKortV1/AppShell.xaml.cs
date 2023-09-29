﻿using MenuKortV1.View;
using MenuKortV1.ViewModel;

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
        }
    }
}