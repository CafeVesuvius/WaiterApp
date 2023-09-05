using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync(nameof(MenuItemPage));
        }

    }
}
