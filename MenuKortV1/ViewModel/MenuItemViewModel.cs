using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MenuKortV1.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    [QueryProperty("SelectedMenu", "Menu")]
    public partial class MenuItemViewModel : ObservableObject
    {
        public MenuItemViewModel() {



        }

        [ObservableProperty]
        Menu selectedMenu;
    }
}
