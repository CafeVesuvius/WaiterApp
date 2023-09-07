using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    public partial class OrdreViewModel : ObservableObject
    {
        [ObservableProperty]
        public string orderName;

        [ObservableProperty]
        ObservableCollection<Model.MenuItem> orderItems;

        public OrdreViewModel(string orderName, ObservableCollection<Model.MenuItem> orderItems)
        {
            OrderName = orderName;
            OrderItems = orderItems;
        }
    }
}
