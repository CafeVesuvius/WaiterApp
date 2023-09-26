using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;

namespace MenuKortV1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        // Define an observable collection for menus
        public ObservableCollection<Menu> Menus { get; set; } = new ObservableCollection<Menu>();

        // Define bool for Show&Hide behaviour for home screen title
        [ObservableProperty]
        bool showTitle = false;

        // Pass menu parameters to a new page
        [RelayCommand]
        async Task OpenMenu(Menu m)
        {
            await Shell.Current.GoToAsync($"{nameof(MenuItemPage)}?", new Dictionary<string, object> { { "Menu" , m } } );
        }

        // Command, which gets/refreshes menu data from the API
        [RelayCommand]
        async Task Refresh()
        {
            // Get data
            var menus = await APIAccess.GetMenu();

            // Check if data isn't null
            if(menus != null)
            {
                // Clear the menu list before refreshing it with new data
                Menus.Clear();

                // Only add active menus to the menu list
                if(!menus.Active)
                {
                    // Remove inactive menu items from the menu
                    foreach (var menuItem in menus.Items)
                    {
                        if (!menuItem.Active)
                        {
                            menus.Items.Remove(menuItem);
                        }
                    }

                    // Add the menus
                    Menus.Add(menus);
                }

                // Only show "Vælg er menu fra listen:" if there is at least one menu in the list
                ShowTitle = true;
            }
            else
            {
                AToastToYou("NO MENUUUUS!!");
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