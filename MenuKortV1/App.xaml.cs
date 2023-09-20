using MenuKortV1.Data;
using MenuKortV1.View;
using MenuKortV1.ViewModel;

namespace MenuKortV1
{
    public partial class App : Application
    {
        public App()
        { 
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}