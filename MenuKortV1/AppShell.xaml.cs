﻿using MenuKortV1.View;

namespace MenuKortV1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MenuItemPage), typeof(MenuItemPage));
        }
    }
}