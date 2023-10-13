using MenuKortV1.Model;

namespace MenuKortV1
{
    public partial class App : Application
    {
        // Define persistent data/Preferences
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