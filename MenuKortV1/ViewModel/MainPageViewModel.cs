using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;

namespace MenuKortV1.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            Menus = new ObservableCollection<Menu>
            {
                new Menu
                {
                    Id = 1,
                    Name = "Test",
                    Season = "Test",
                    Active = true,
                    Changed_TS = DateTime.Now,
                    Items = new List<Model.MenuItem>()
                },
                new Menu 
                { 
                    Id = 2,
                    Name = "Test 2",
                    Season = "Test 2",
                    Active = true,
                    Changed_TS = DateTime.Now,
                    Items = new List<Model.MenuItem>()
                }
            };
        }

        [ObservableProperty]
        ObservableCollection<Menu> menus;

        [ObservableProperty]
        string menuName;

        [RelayCommand]
        async Task Tap(Menu m)
        {
            await Shell.Current.GoToAsync($"{nameof(MenuItemPage)}?Name={m.Name}");
        }

    }
}
