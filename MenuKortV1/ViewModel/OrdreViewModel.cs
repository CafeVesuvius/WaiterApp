using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.ViewModel
{
    // Pass parameters from "MenuItemViewModel"
    [QueryProperty("Order", "NewItem")]

    public partial class OrdreViewModel : ObservableObject
    {
        //
        public OrdreViewModel()
        {
        }

        //Define observable collection for the current order
        [ObservableProperty]
        ObservableCollection<MenuItem> order = new ObservableCollection<MenuItem>();

        [ObservableProperty]
        string note = "";

        [ObservableProperty]
        Editor thisEditor = new Editor();

        //[ObservableProperty]
        //bool noteIsEnabled = false;

        //[ObservableProperty]
        //string dynamicButtonName = "Redigere";

        [RelayCommand]
        void ResetOrder()
        {
            Order.Clear();
        }

        [RelayCommand]
        void RemoveThisItemFromOrder(MenuItem mi)
        {
            Order.Remove(mi);
        }

        //[RelayCommand]
        //void ShowHideNoteField(Editor e)
        //{
        //    //switch (NoteIsEnabled)
        //    //{
        //    //    case true:
        //    //        NoteIsEnabled = false;
        //    //        DynamicButtonName = "Redigere";
        //    //        break;

        //    //    case false:
        //    //        NoteIsEnabled = true;
        //    //        DynamicButtonName = "Gem";
        //    //        break;
        //    //}
        //}

    }
}
