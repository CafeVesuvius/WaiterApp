using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
        //
        public MainViewModel()
        {
        }

        // Define OP for a dymanic page title.
        [ObservableProperty]
        private string pageTitle = "Ordre";

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

        //
        [ObservableProperty]
        bool showOrderLinesManager = false;

        //
        [ObservableProperty]
        bool showOrderCreationMenu = true;

        // Function to open new order
        [RelayCommand]
        async Task OpenNewOrder()
        {
            // Soft Keyboard Showe/Hide Trick
            EntryEnablerDisabler = false;
            EntryEnablerDisabler = true;

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

                PageTitle = MyOrder.Name;

                var orderPosterResponse = await APIAccess.OrderPoster(MyOrder);

                if (!orderPosterResponse)
                {
                    CustomCommands.AToastToYou("GO FUK YOURSELFFF!");
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
                        CustomCommands.AToastToYou("Error finding order");
                    }
                }
            }
            else
            {
                // If the order name field is empty, show this popup
                CustomCommands.AToastToYou("Du mangler at indtaste ordre navn.");
            }
        }

        [RelayCommand]
        async Task OpenMenuList()
        {
            await Shell.Current.GoToAsync($"{nameof(MenusPage)}?", new Dictionary<string, object> { { "MyOrder", MyOrder }, { "OrderLines", OrderLines } });
        }

        // Define editor/text field for order notes
        public Editor ThisEditor { get; set; } = new Editor();

        // Define a command, which clears an order
        [RelayCommand]
        void ResetOrder()
        {
            OrderLines.Clear();
        }

        // Define a command, which removes a specific item from an order
        [RelayCommand]
        void RemoveThisItemFromOrder(MenuItem mi)
        {
            OrderLines.Remove(mi);
        }

        // Send the order to API/kitchen
        [RelayCommand]
        async Task SendOrdre()
        {
            foreach (MenuItem mi in OrderLines)
            {
                OrderLine ol = new OrderLine
                {
                    Id = 0,
                    Quantity = 1,
                    Detail = ThisEditor.Text,
                    MenuItemID = mi.Id,
                    OrderID = MyOrder.Id,
                };
                
                await APIAccess.OrderLinePoster(ol);
            }
        }
    }
}