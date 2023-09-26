using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    public partial class OrdrePageViewModel : ObservableObject
    {
        public OrdrePageViewModel() 
        {

        }

        // Define OP string for storing the order name
        [ObservableProperty]
        private string orderName;

        // Define OP bool for the entry's "IsEnabled"
        [ObservableProperty]
        bool entryEnablerDisabler = true;

        [ObservableProperty]
        Order myOrder;

        // Function to post order
        [RelayCommand]
        async Task PostOrderAsync()
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

                // Post order to API & get response
                var boing = await APIAccess.OrderPoster(MyOrder);

                AToastToYou(boing);

                // If there is response -> continue
                //if (boing == ":3")
                //{
                //    await Shell.Current.GoToAsync(nameof(OrdreDetailsPage));
                //}
                //else
                //{
                //    AToastToYou(boing);
                //}
                
            }
            else
            {
                // If the order name field is empty, show this popup
                AToastToYou("Du mangler at indtaste ordre navn.");
            }
        }

        // Dynamisk "Toast" (popup) function
        public static Task AToastToYou(string toastText)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var yourToast = Toast.Make(toastText, ToastDuration.Short, 14).Show(cts.Token);
            return yourToast;
        }
    }
}
