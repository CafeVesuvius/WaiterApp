using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;

namespace MenuKortV1.ViewModel
{
    // Get new order lines from "MenuItemViewModel"
    [QueryProperty("OrderLines", "OrderLines")]

    public partial class MainViewModel : ObservableObject
    {
        // Define OP string for storing the order name
        [ObservableProperty]
        private string orderName;

        // Define OP bool for the entry's "IsEnabled"
        [ObservableProperty]
        bool entryEnablerDisabler = true;

        // Define "Order" object
        [ObservableProperty]
        Order myOrder;

        // Define observable collection for the current order's order lines
        [ObservableProperty]
        ObservableCollection<MenuItem> orderLines = new ObservableCollection<MenuItem>();

        // Dynamic page content for order details. Shown when an order is created.
        [ObservableProperty]
        bool showOrderLinesManager = false;

        // Dynamic page content to show order creation menu. Hide after creating an order.
        [ObservableProperty]
        bool showOrderCreationMenu = true;

        // Dybamic pool to show/hide menu item list and "send order" button only if there are order lines
        [ObservableProperty]
        bool showItemList = false;

        // Function to create/open new order
        [RelayCommand]
        async Task OpenNewOrder()
        {
            // Hide soft keyboard
            SoftKeyboardShowerHider();

            // Check if the order name field is not empty
            if (!string.IsNullOrEmpty(OrderName))
            {
                // If the order name isn't empty, create the order
                MyOrder = new Order()
                {
                    Name = OrderName,
                    CreatedDate = DateTime.Now,
                    IsCompleted = false,
                    OrderLines = new List<OrderLine>() { }
                };

                // Hide the order creation menu - show the order management menu
                ShowOrderLinesManager = true;
                ShowOrderCreationMenu = false;

                // Try to create order, get bool
                var orderPosterResponse = await APIAccess.OrderPoster(MyOrder);
                if (!orderPosterResponse)
                {
                    // If the order couldn't be created
                    await Shell.Current.DisplayAlert("ERROR", "Ordre kan ikke opretes.", "OK");
                }
                else
                {
                    // Get the ID of the freshly created order
                    var idYoinker = await APIAccess.GetOrderId(MyOrder);

                    // If the ID is found, continue
                    if (idYoinker != 0)
                    {
                        MyOrder.Id = idYoinker;
                    }
                    else
                    {
                        // If not, show error message
                        await Shell.Current.DisplayAlert("ERROR", "Ordre ID ikke findes.", "OK");
                    }
                }
            }
            else
            {
                // If the order name field is empty, show this alert
                await Shell.Current.DisplayAlert("Besked", "Du mangler at indtaste ordre navn.", "OK");
            }
        }

        // Navigate to menu list page
        [RelayCommand]
        async Task OpenMenuList()
        {
            SoftKeyboardShowerHider();
            ShowItemList = true;

            await Shell.Current.GoToAsync($"{nameof(MenusPage)}?", new Dictionary<string, object> { { "MyOrder", MyOrder }, { "OrderLines", OrderLines } });
        }

        // Clear the whole order and delete it from the API
        [RelayCommand]
        async Task ResetOrder()
        {
            var response = await APIAccess.OrderDeleter(MyOrder);

            if(response) {
                OrderLines.Clear();
                MyOrder = null;
                OrderName = string.Empty;
                ShowOrderLinesManager = false;
                ShowOrderCreationMenu = true;
            }
        }

        // Post the order to API + Save to Preferences
        [RelayCommand]
        async Task SendOrdre()
        {
            // Go though the order lines and post them
            foreach (MenuItem mi in OrderLines)
            {
                OrderLine ol = new OrderLine
                {
                    Id = 0,
                    Quantity = mi.Quantity,
                    Detail = mi.Detail,
                    MenuItemID = mi.Id,
                    OrderID = MyOrder.Id
                };
                
                await APIAccess.OrderLinePoster(ol);
            }

            // Get preferences string for order data
            string checkPersistentOrderData = Preferences.Get(nameof(App.PersistentOrder), "");

            // If string is null - there's no saved data, so create it.
            if (string.IsNullOrWhiteSpace(checkPersistentOrderData))
            {
                PersistentOrder po = new PersistentOrder { PersistentOrders = new List<Order> { MyOrder } };
                string persistentOrderstStr = JsonConvert.SerializeObject(po);
                Preferences.Set(nameof(App.PersistentOrder), persistentOrderstStr);
            }
            else
            {
                // If there is already data, update it
                PersistentOrder currentPO = JsonConvert.DeserializeObject<PersistentOrder>(checkPersistentOrderData);
                currentPO.PersistentOrders.Add(MyOrder);
                string persistentOrderstStr = JsonConvert.SerializeObject(currentPO);
                Preferences.Set(nameof(App.PersistentOrder), persistentOrderstStr);
            }

            // Clear order and order lines
            OrderLines.Clear();
            MyOrder = null;
            OrderName = string.Empty;
            ShowOrderLinesManager = false;
            ShowOrderCreationMenu = true;
        }

        // Increase quantity of a menu item
        [RelayCommand]
        static void IncreaseMenuItemQuantity(MenuItem mi)
        {
            mi.Quantity += 1;
        }

        // Decrease quantity of a menu item
        [RelayCommand]
        void DecreaseMenuItemQuantity(MenuItem mi)
        {
            if(mi.Quantity == 1)
            {
                // If the quantity reaches 0, automatically remove the item from the list
                OrderLines.Remove(mi);
                if(OrderLines.Count == 0)
                {
                    ShowItemList = false;
                }
            }
            else if(mi.Quantity > 0 && mi.Quantity != 1)
            {
                mi.Quantity -= 1;
            }
        }

        // Trick to hide soft keyboard
        void SoftKeyboardShowerHider()
        {
            // Soft Keyboard Show/Hide Trick
            EntryEnablerDisabler = false;
            EntryEnablerDisabler = true;
        }
    }
}