using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    //[QueryProperty("chosenMenuItem", "NewItem")]

    public partial class OrdreViewModel : ObservableObject
    {
        public OrdreViewModel()
        {
            //Order = new ObservableCollection<MenuItem>();
        }

        [ObservableProperty]
        ObservableCollection<MenuItem> order = new ObservableCollection<MenuItem>();
        //MenuItem chosenMenuItem;

        public void AddingItem(MenuItem mi)
        {
            Order.Add(mi);
        }
    }
}
