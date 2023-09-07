using CommunityToolkit.Mvvm.ComponentModel;
using MenuKortV1.Model;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using MenuKortV1.ViewModel;

namespace MenuKortV1.ViewModel
{
    [QueryProperty("SelectedMenu", "Menu")] // Hent parameterne, der bliver medsendt hos "OpenMenu" commandoen fra 'MainViewModel'

    public partial class MenuItemViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ViewModel.OrdreViewModel> orders;

        public MenuItemViewModel() 
        {
            orders = new ObservableCollection<ViewModel.OrdreViewModel>();
        }

        [ObservableProperty]
        Menu selectedMenu;

        public void AddItem(Model.MenuItem mi)
        {
            //Orders.Add(new ViewModel.OrdreViewModel { OrderName = "test", OrderItems = mi);
            //await Shell.Current.GoToAsync(nameof(OrdrePage), new Dictionary<string, object> { { "NewItem", mi } });
        }
    }
}

//https://stackoverflow.com/questions/16506653/accessing-a-property-in-one-viewmodel-from-another
