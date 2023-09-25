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

        // Define observable collection for the current order
        [ObservableProperty]
        ObservableCollection<MenuItem> order = new ObservableCollection<MenuItem>();

        // Define a string variable to store notes for the order
        [ObservableProperty]
        string note = "";

        // Define editor/text field for order notes
        public Editor ThisEditor { get; set; } = new Editor();

        // Define a command, which clears an order
        [RelayCommand]
        void ResetOrder()
        {
            Order.Clear();
        }

        // Define a command, which removes a specific item from an order
        [RelayCommand]
        void RemoveThisItemFromOrder(MenuItem mi)
        {
            Order.Remove(mi);
        }

        // Save the input in a variable
        [RelayCommand]
        void SendOrdre()
        {
            Note = ThisEditor.Text;
        }
    }
}
