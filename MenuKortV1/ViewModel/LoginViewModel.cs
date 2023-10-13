using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using Newtonsoft.Json;

namespace MenuKortV1.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        // OP to store username from login input
        [ObservableProperty]
        string userName;

        // OP to store password from login input
        [ObservableProperty]
        string password;

        // Login command
        [RelayCommand]
        async Task Login()
        {
            // If both username and password AREN'T empty
            if(!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password)) 
            {
                // Attempt to login with the user input
                ILoginService loginService = new LoginService();
                var response = await loginService.Authenticate
                ( 
                    new LoginRequest
                    {
                        Username = UserName,
                        Password = Password,
                    }
                );

                // If login is successful
                if (response != null)
                {
                    // Save user data
                    response.UserLoginInfo = new UserLoginInfo
                    {
                        Username = UserName,
                        RoleId = (int)UserLoginInfo.RoleDetails.Waiter,
                        RoleName = "Tjener"
                    };

                    // Remove old user data
                    if (Preferences.ContainsKey(nameof(App.UserLoginInfo)))
                    {
                        Preferences.Remove(nameof(App.UserLoginInfo));
                    }

                    // Set user login data and token
                    await SecureStorage.SetAsync(nameof(App.Token), response.Token);
                    string userLoginInfo = JsonConvert.SerializeObject(response.UserLoginInfo);
                    Preferences.Set(nameof(App.UserLoginInfo), userLoginInfo);
                    App.UserLoginInfo = response.UserLoginInfo;
                    App.Token = response.Token;

                    // Redirect to main page
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Felj", "Ugyldig login oplysninger.", "OK");
                }
            }
            else // if "username" and/or "password" field are empty
            {
                if (string.IsNullOrWhiteSpace(UserName))
                {
                    await Shell.Current.DisplayAlert("Fejl", "Du mangler at indtaste brugernavn.", "OK");
                }
                else if (string.IsNullOrWhiteSpace(Password))
                {
                    await Shell.Current.DisplayAlert("Fejl", "Du mangler at indtaste afgangskode.", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("ERROR", "Fejl ved login.", "OK");
                }
            }
        }
    }
}
