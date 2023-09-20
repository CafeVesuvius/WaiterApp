using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
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

        // Get data from API
        [RelayCommand]
        async Task Refresh()
        {
            var menus = await APIAccess.GetMenu();
            if(menus != null)
            {
                Menus.Clear();
                if(!menus.Active)
                {
                    Menus.Add(menus);
                }
            }
        }
    }
}