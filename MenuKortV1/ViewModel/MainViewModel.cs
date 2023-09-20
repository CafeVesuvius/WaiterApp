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
                Menus.Clear();
                // Only add active menus to the menu list
                if(!menus.Active)
                {
                    Menus.Add(menus);
                }  
            }
        }
    }
}