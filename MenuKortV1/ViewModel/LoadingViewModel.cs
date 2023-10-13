using CommunityToolkit.Mvvm.ComponentModel;
using MenuKortV1.Model;
using MenuKortV1.View;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace MenuKortV1.ViewModel
{
    public partial class LoadingViewModel : ObservableObject
    {
        public LoadingViewModel()
        {
            // User login + token validity check
            CheckUserLoginDetails();
        }

        async void CheckUserLoginDetails()
        {
            // Look for persistent data
            string userLoginInfo = Preferences.Get(nameof(App.UserLoginInfo), "");

            if (string.IsNullOrWhiteSpace(userLoginInfo))
            {
                // If there's no login data, redirect to login page
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            else // login data found
            {
                // Get the token from persistent data
                var tokenDetail = await SecureStorage.GetAsync(nameof(App.Token));

                // Check if the token is valid or expired
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(tokenDetail) as JwtSecurityToken;

                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    // Redirect to login page if token has expired
                    await Shell.Current.DisplayAlert("User session expired", "Login again to continue", "Ok");
                    await Shell.Current.GoToAsync(nameof(LoginPage));
                }
                else
                {
                    // Redirect to main page if saved login and token are valid
                    var userInfo = JsonConvert.DeserializeObject<UserLoginInfo>(userLoginInfo);
                    App.UserLoginInfo = userInfo;
                    App.Token = tokenDetail;
                    await Shell.Current.GoToAsync("//MainPage");
                }
            }

        }
    }
}
