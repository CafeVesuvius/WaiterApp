using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MenuKortV1.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.View;

namespace MenuKortV1.ViewModel
{
    // Hent parameterne, der bliver medsendt hos "OpenMenu" commandoen fra 'MainViewModel'
    [QueryProperty("SelectedMenu", "Menu")]

    public partial class MenuItemViewModel : ObservableObject
    {
        public MenuItemViewModel() { }

        // Observable property/variable, der gemmer parameterne
        [ObservableProperty]
        Menu selectedMenu;

        // Navigation
        [RelayCommand]
        async Task OpenMenuItem(Model.MenuItem mi)
        {
            await Shell.Current.GoToAsync(nameof(MenuItemPage));
        }
    }
}
