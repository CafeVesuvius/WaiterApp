using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using MenuItem = MenuKortV1.Model.MenuItem;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;

namespace MenuKortV1.ViewModel
{
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

        // Function to open new order
        [RelayCommand]
        async Task OpenNewOrder()
        {
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

                ShowOrderLinesManager = true;
                ShowOrderCreationMenu = false;

                var orderPosterResponse = await APIAccess.OrderPoster(MyOrder);

                if (!orderPosterResponse)
                {
                    CustomCommands.AToastToYou("ERROR: Ordre kan ikke opretes.");
                }
                else
                {
                    var idYoinker = await APIAccess.GetOrderId(MyOrder);
                    if (idYoinker != 0)
                    {
                        MyOrder.Id = idYoinker;
                    }
                    else
                    {
                        CustomCommands.AToastToYou("ERROR: Ordre ID ikke findes");
                    }
                }
            }
            else
            {
                // If the order name field is empty, show this popup
                CustomCommands.AToastToYou("Du mangler at indtaste ordre navn.");
            }
        }

        // Navigate to menu list page
        [RelayCommand]
        async Task OpenMenuList()
        {
            SoftKeyboardShowerHider();
            await Shell.Current.GoToAsync($"{nameof(MenusPage)}?", new Dictionary<string, object> { { "MyOrder", MyOrder }, { "OrderLines", OrderLines } });
        }

        // Clear the whole order and delete it from the API
        [RelayCommand]
        async void ResetOrder()
        {
            var response = await APIAccess.OrderDeleter(MyOrder);
            if(response)
            {
                OrderLines.Clear();
                MyOrder = null;
                OrderName = string.Empty;
                ShowOrderLinesManager = false;
                ShowOrderCreationMenu = true;
            }
        }

        // Post the order to API
        [RelayCommand]
        async Task SendOrdre()
        {
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

            // Clear order and order lines
            OrderLines.Clear();
            MyOrder = null;
            OrderName = string.Empty;
            ShowOrderLinesManager = false;
            ShowOrderCreationMenu = true;
        }

        // Increase quantity of a menu item
        [RelayCommand]
        void IncreaseMenuItemQuantity(MenuItem mi)
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