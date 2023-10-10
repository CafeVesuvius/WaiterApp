using MenuKortV1.Model;
using MenuKortV1.ViewModel;

namespace MenuKortV1
{
    public partial class App : Application
    {
        // Define persistent data
        public static UserLoginInfo UserLoginInfo;
        public static PersistentOrder PersistentOrder;
        public static string Token;

        public App()
        { 
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}