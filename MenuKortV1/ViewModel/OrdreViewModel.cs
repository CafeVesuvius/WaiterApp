using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    // Pass parameters from "MenuItemViewModel"
    [QueryProperty("Order", "NewItem")]

    public partial class OrdreViewModel : ObservableObject
    {
        //public OrdreViewModel()
        //{
        //}

        //Define observable collection for the current order
        [ObservableProperty]
        ObservableCollection<MenuItem> order = new ObservableCollection<MenuItem>();

        [ObservableProperty]
        string fullPrice;
    }
}
