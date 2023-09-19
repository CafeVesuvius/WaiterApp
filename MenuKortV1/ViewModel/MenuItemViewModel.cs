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

        [ObservableProperty]
        OrdreViewModel ovm = new OrdreViewModel();

        // Add menu items to an order
        [RelayCommand]
        void AddItem(MenuItem mi)
        {
            Ovm.AddingItem(mi);
        }

    }
}