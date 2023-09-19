using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;

namespace MenuKortV1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Menu> Menus { get; set; } = new ObservableCollection<Menu>();

        public MainViewModel()
        {
            //Menus = new ObservableCollection<Menu>();
        }

        // Commando der navigerer til nye side med en bestemt menukorts varer (sender parameter)
        [RelayCommand]
        async Task OpenMenu(Menu m)
        {
            await Shell.Current.GoToAsync($"{nameof(MenuItemPage)}?", new Dictionary<string, object> { { "Menu" , m } } );
        }

        [RelayCommand]
        async Task Refresh()
        {
            Menus.Clear();
            var menus = await APIAccess.GetMenu();
            Menus.Add(menus);
        }
    }
}

//Placeholder data
//Menus = new ObservableCollection<Menu>
//{
//    new Menu
//    {
//        Id = 1,
//        Name = "Test",
//        Season = "Test",
//        Active = true,
//        Changed_TS = DateTime.Now,
//        Items = new List<Model.MenuItem>()
//        {
//            new Model.MenuItem
//            {
//                Id = 1,
//                Name = "Grimer Shake",
//                Description = "urrrple",
//                UnitPrice = "300",
//                Active = true,
//                MenuID = 1
//            }
//        }
//    },
//    new Menu
//    {
//        Id = 2,
//        Name = "Test 2",
//        Season = "Test 2",
//        Active = true,
//        Changed_TS = DateTime.Now,
//        Items = new List<Model.MenuItem>()
//        {
//            new Model.MenuItem
//            {
//                Id = 1,
//                Name = "asdasdas",
//                Description = "a",
//                UnitPrice = "300",
//                Active = true,
//                MenuID = 1
//            }
//        }
//    }
//};