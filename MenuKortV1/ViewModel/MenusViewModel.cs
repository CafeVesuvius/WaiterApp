using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    // Pass order parameters from "MainViewModel"
    [QueryProperty("OrderLines", "OrderLines")]

    public partial class MenusViewModel : ObservableObject
    {
        // Define an observable collection for menus
        public ObservableCollection<Menu> Menus { get; set; } = new ObservableCollection<Menu>();

        public MenusViewModel() 
        {
            // Load all menu data on routing
            Refresh();
        }

        // Define bool for Show&Hide behaviour for home screen title
        [ObservableProperty]
        bool showTitle = false;

        // Define "Order" object
        [ObservableProperty]
        Order myOrder;

        // Define observable collection for the current order's order lines
        [ObservableProperty]
        ObservableCollection<MenuItem> orderLines = new ObservableCollection<MenuItem>();

        // Pass menu parameters to a new page
        [RelayCommand]
        async Task OpenMenu(Menu m)
        {
            await Shell.Current.GoToAsync($"{nameof(MenuItemPage)}?", new Dictionary<string, object> { { "Menu", m }, { "OrderLines", OrderLines } });
        }

        // Command, which gets/refreshes menu data from the API
        [RelayCommand]
        async Task Refresh()
        {
            // Get menu data
            var menus = await APIAccess.GetMenu();

            // Check if menu data isn't null
            if (menus.Any())
            {
                // Clear the menu list before refreshing it with new data
                Menus.Clear();

                foreach (var menu in menus.ToList())
                {
                    // Remove inactive menu items from the menu
                    foreach (var menuItem in menu.Items.ToList())
                    {
                        if (!menuItem.Active)
                        {
                            menu.Items.Remove(menuItem);
                        }
                    }

                    //Add the menu to the menu list
                    Menus.Add(menu);
                }

                // Only show "Vælg er menu fra listen:" if there is at least one menu in the list
                ShowTitle = true;
            }
            else
            {
                await Shell.Current.DisplayAlert("Fejl", "Der findes ikke noget menuer.", "OK");
            }
        }
    }
}
