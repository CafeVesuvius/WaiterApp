using MenuKortV1.ViewModel;

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