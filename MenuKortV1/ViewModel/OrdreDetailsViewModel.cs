using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    // Pass parameters from "MenuItemViewModel"
    [QueryProperty("Order", "NewItem")]
    //
    [QueryProperty("CurrentOrder", "ThisOrder")]

    public partial class OrdreDetailsViewModel : ObservableObject
    {
        //
        public OrdreDetailsViewModel()
        {
            if(currentOrder is not null)
            {
                DoesOrderExists = true;
            }
            else
            {
                DoesOrderExists = false;
            }
        }

        public bool DoesOrderExists = false;

        //
        [ObservableProperty]
        Order currentOrder = new Order();

        // Define observable collection for the current order
        [ObservableProperty]
        ObservableCollection<MenuItem> order = new ObservableCollection<MenuItem>();

        // Define a string variable to store notes for the order
        [ObservableProperty]
        string note = "";

        // Define editor/text field for order notes
        public Editor ThisEditor { get; set; } = new Editor();

        // Define a command, which clears an order
        [RelayCommand]
        void ResetOrder()
        {
            Order.Clear();
        }

        // Define a command, which removes a specific item from an order
        [RelayCommand]
        void RemoveThisItemFromOrder(MenuItem mi)
        {
            Order.Remove(mi);
        }

        // Send the order to API/kitchen
        [RelayCommand]
        async Task SendOrdre()
        {
            //Note = ThisEditor.Text;

            foreach (MenuItem mi in Order) 
            {
                OrderLine ol = new OrderLine
                {
                    Id = CurrentOrder.OrderLines.Count + 1,
                    Quantity = 1,
                    Detail = ThisEditor.Text,
                    MenuItemID = mi.Id
                };

                CurrentOrder.OrderLines.Add(ol);
            }

            //Post order to API & get response
            var orderPosterResponse = await APIAccess.OrderPoster(CurrentOrder);

            if(orderPosterResponse)
            {
                Order.Clear();
                Order = null;
                CurrentOrder = null;
                await Shell.Current.GoToAsync(nameof(OrdrePage));
            }
            else
            {
                MainViewModel.AToastToYou("ERROR");
            }
        }
    }
}
