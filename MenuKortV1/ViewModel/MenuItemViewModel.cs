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
        ObservableCollection<MenuItem> tempList = new ObservableCollection<MenuItem>();

        public OrdreViewModel Ovm = new OrdreViewModel();

        //Add menu items to an order
       [RelayCommand]
        async Task AddItem(MenuItem mi)
        {
            TempList.Add(mi);
            await Shell.Current.GoToAsync($"{nameof(OrdrePage)}?", new Dictionary<string, object> { { "NewItem", TempList } });
        }

        //[RelayCommand]
        //void AddItem(MenuItem mi)
        //{
        //    Ovm.Order.Add(mi);
        //}

    }
}