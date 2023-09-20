using MenuKortV1.Data;
using MenuKortV1.ViewModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MenuKortV1
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }
}