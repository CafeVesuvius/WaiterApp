using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Model;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    // Get parameters, which are sent via the "OpenMenu" command from 'MenusViewModel'
    [QueryProperty("SelectedMenu", "Menu")]
    [QueryProperty("OrderLines", "OrderLines")]

    public partial class MenuItemViewModel : ObservableObject
    {
        // Define the query property, which stores passed parameters
        [ObservableProperty]
        Menu selectedMenu;

        // Define observable collection for the current order's order lines
        [ObservableProperty]
        ObservableCollection<MenuItem> orderLines = new ObservableCollection<MenuItem>();

        // Add menu items to an order
        [RelayCommand]
        async Task AddItem(MenuItem mi)
        {
            // Add new items/order lines to the order
            if (OrderLines.Contains(mi))
            {
                // Stack quantity if the item is already in the list
                var existingItem = OrderLines.Where(x => x.MenuID == mi.MenuID).FirstOrDefault();
                existingItem.Quantity += 1;
            }
            else
            {
                mi.Quantity = 1; 
                OrderLines.Add(mi);
            }
           
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}?", new Dictionary<string, object> { { "OrderLines", OrderLines } });
        }
    }
}