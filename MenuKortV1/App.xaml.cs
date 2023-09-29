using MenuKortV1.Model;

namespace MenuKortV1
{
    public partial class App : Application
    {
        // Define persistent data
        public static UserLoginInfo UserLoginInfo;
        public static PersistentOrder PersistentOrder;

        public App()
        { 
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}