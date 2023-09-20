using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    [QueryProperty("Order", "NewItem")]

    public partial class OrdreViewModel : ObservableObject
    {
        //public ObservableCollection<MenuItem> Order { get; set; } = new ObservableCollection<MenuItem>();

        public OrdreViewModel()
        {
            //Order.Add(new MenuItem{ Id = 666, Name = "Grimer Shake", Description = "urrrple", UnitPrice = "1", MenuID = 1});
            //Order.Add(ChosenMenuItem);
            //AddingItem(ChosenMenuItem);
        }

        [ObservableProperty]
        //MenuItem chosenMenuItem;
        ObservableCollection<MenuItem> order = new ObservableCollection<MenuItem>();


        //public void AddingItem(MenuItem mi)
        //{
        //    Order.Add(mi);
        //}
    }
}
