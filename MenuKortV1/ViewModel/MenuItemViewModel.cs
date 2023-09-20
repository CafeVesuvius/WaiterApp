using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    // Get parameters, which are sent via the "OpenMenu" command from 'MainViewModel'
    [QueryProperty("SelectedMenu", "Menu")] 

    public partial class MenuItemViewModel : ObservableObject
    {
        // Define the query property, which stores passed parameters
        [ObservableProperty]
        Menu selectedMenu;

        // Define an observable collection for order
        [ObservableProperty]
        ObservableCollection<MenuItem> order = new ObservableCollection<MenuItem>();

        //Add menu items to an order
        [RelayCommand]
        async Task AddItem(MenuItem mi)
        {
            // Add items to the collection
            Order.Add(mi);

            // Pass the collection to a new page
            await Shell.Current.GoToAsync($"{nameof(OrdrePage)}?", new Dictionary<string, object> { { "NewItem", Order } });
        }
    }
}