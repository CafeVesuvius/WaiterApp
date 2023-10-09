using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    public partial class ActiveOrdersViewModel : ObservableObject
    {
        public ActiveOrdersViewModel() 
        {
            Refresh();
        }

        [ObservableProperty]
        int rowCounter;

        [ObservableProperty]
        PersistentOrder persistentOrder = new PersistentOrder();

        [ObservableProperty]
        List<Order> currentOrders = new List<Order>();

        [RelayCommand]
        void Refresh()
        {
            // Clear
            PersistentOrder = null;
            CurrentOrders.Clear();

            // Get
            string checkPersistentOrderData = Preferences.Get(nameof(App.PersistentOrder), "");
            PersistentOrder currentPO = JsonConvert.DeserializeObject<PersistentOrder>(checkPersistentOrderData);
            PersistentOrder = currentPO;
            CurrentOrders = PersistentOrder.PersistentOrders.ToList();

            RowCounter = CurrentOrders.Count;
        }

        [RelayCommand]
        void Remove(Order o)
        {
            string checkPersistentOrderData = Preferences.Get(nameof(App.PersistentOrder), "");
            PersistentOrder.PersistentOrders.Remove(o);
            string persistentOrderstStr = JsonConvert.SerializeObject(PersistentOrder);
            Preferences.Set(nameof(App.PersistentOrder), persistentOrderstStr);

            Refresh();
        }
    }
}
