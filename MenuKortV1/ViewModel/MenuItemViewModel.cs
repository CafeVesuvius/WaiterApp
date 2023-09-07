using CommunityToolkit.Mvvm.ComponentModel;
using MenuKortV1.Model;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

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
        async Task ViewItemInfo(MenuItem m)
        {
            await Shell.Current.GoToAsync(nameof(ItemInfo), new Dictionary<string, object> { { "SelectedMenuItem", m } });
        }
    }
}
