using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MenuKortV1.Data;
using MenuKortV1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {

        }

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string password;

        [RelayCommand]
        async Task Login()
        {
            if(!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password)) 
            {
                ILoginService loginService = new LoginService();
                var response = await loginService.Authenticate
                ( 
                    new LoginRequest
                    {
                        Username = UserName,
                        Password = Password,
                    }
                );

                if (response != null)
                {
                    response.UserLoginInfo = new UserLoginInfo
                    {
                        Username = UserName,
                        RoleId = (int)UserLoginInfo.RoleDetails.Waiter,
                        RoleName = "Tjener"
                    };

                    if (Preferences.ContainsKey(nameof(App.UserLoginInfo)))
                    {
                        Preferences.Remove(nameof(App.UserLoginInfo));
                    }

                    await SecureStorage.SetAsync(nameof(App.Token), response.Token);

                    string userLoginInfo = JsonConvert.SerializeObject(response.UserLoginInfo);
                    Preferences.Set(nameof(App.UserLoginInfo), userLoginInfo);
                    App.UserLoginInfo = response.UserLoginInfo;
                    App.Token = response.Token;
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Felj", "Ugyldig login oplysninger.", "OK");
                }
            }
            else
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
