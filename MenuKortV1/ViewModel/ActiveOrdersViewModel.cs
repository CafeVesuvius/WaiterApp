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

        // Define OP counter for orders
        [ObservableProperty]
        int rowCounter;

        // Define OP to store persistent data about the orders
        [ObservableProperty]
        PersistentOrder persistentOrder = new PersistentOrder();

        // Define OP to store the list of orders in the preferences
        [ObservableProperty]
        List<Order> currentOrders = new List<Order>();

        // Command to refresh the order list
        [RelayCommand]
        void Refresh()
        {
            // Overwrite existing data
            PersistentOrder = null;
            CurrentOrders.Clear();
            string checkPersistentOrderData = Preferences.Get(nameof(App.PersistentOrder), "");
            PersistentOrder currentPO = JsonConvert.DeserializeObject<PersistentOrder>(checkPersistentOrderData);
            PersistentOrder = currentPO;
            CurrentOrders = PersistentOrder.PersistentOrders.ToList();

            // Show a counter the current orders for delivering
            RowCounter = CurrentOrders.Count;
        }

        [RelayCommand]
        void Remove(Order o)
        {
            // Remove item from preferences
            string checkPersistentOrderData = Preferences.Get(nameof(App.PersistentOrder), "");
            PersistentOrder.PersistentOrders.Remove(o);
            string persistentOrderstStr = JsonConvert.SerializeObject(PersistentOrder);
            Preferences.Set(nameof(App.PersistentOrder), persistentOrderstStr);

            // Auto overwrite
            Refresh();
        }
    }
}
