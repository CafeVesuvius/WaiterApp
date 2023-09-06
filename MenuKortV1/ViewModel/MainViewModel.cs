using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Model;
using MenuKortV1.View;
using System.Collections.ObjectModel;

namespace MenuKortV1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            // Placeholder data
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
                    {
                        new Model.MenuItem
                        {
                            Id = 1,
                            Name = "Grimer Shake",
                            Description = "urrrple",
                            UnitPrice = "300",
                            Active = true,
                            MenuID = 1
                        }
                    }
                },
                new Menu
                {
                    Id = 2,
                    Name = "Test 2",
                    Season = "Test 2",
                    Active = true,
                    Changed_TS = DateTime.Now,
                    Items = new List<Model.MenuItem>()
                    {
                        new Model.MenuItem
                        {
                            Id = 1,
                            Name = "asdasdas",
                            Description = "a",
                            UnitPrice = "300",
                            Active = true,
                            MenuID = 1
                        }
                    }
                }
            };
        }

        // Observable collection der indeholder CafeVesuvius menukort
        [ObservableProperty]
        ObservableCollection<Menu> menus;

        // Commando der navigerer til nye side med en bestemt menukorts varer (sender parameter)
        [RelayCommand]
        async Task OpenMenu(Menu m)
        {
            await Shell.Current.GoToAsync($"{nameof(MenuItemPage)}?",
                new Dictionary<string, object>
                {
                    { "Menu" , m },
                });
        }

    }
}
