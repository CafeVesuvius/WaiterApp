using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Model;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    // Get parameters, which are sent via the "OpenMenu" command from 'MainViewModel'
    [QueryProperty("SelectedMenu", "Menu")]
    [QueryProperty("MyOrder", "MyOrder")]
    [QueryProperty("OrderLines", "OrderLines")]

    public partial class MenuItemViewModel : ObservableObject
    {

        public MenuItemViewModel() 
        {
        }

        // Define the query property, which stores passed parameters
        [ObservableProperty]
        Menu selectedMenu;

        // Define "Order" object
        [ObservableProperty]
        Order myOrder;

        // Define observable collection for the current order's order lines
        [ObservableProperty]
        ObservableCollection<MenuItem> orderLines = new ObservableCollection<MenuItem>();

        //Add menu items to an order
        [RelayCommand]
        async Task AddItem(MenuItem mi)
        {
            // Add items to the collection
            if (OrderLines.Contains(mi))
            {
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