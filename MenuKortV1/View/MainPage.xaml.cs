using MenuKortV1.ViewModel;

namespace MenuKortV1
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}