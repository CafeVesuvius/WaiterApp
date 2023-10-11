using CommunityToolkit.Mvvm.ComponentModel;
using MenuKortV1.Data;
using MenuKortV1.Model;
using MenuKortV1.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.ViewModel
{
    public partial class LoadingViewModel : ObservableObject
    {
        public LoadingViewModel()
        {
            CheckUserLoginDetails();
        }

        async void CheckUserLoginDetails()
        {
            string userLoginInfo = Preferences.Get(nameof(App.UserLoginInfo), "");

            if (string.IsNullOrWhiteSpace(userLoginInfo))
            {
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            else
            {
                var tokenDetail = await SecureStorage.GetAsync(nameof(App.Token));

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(tokenDetail) as JwtSecurityToken;

                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    await Shell.Current.DisplayAlert("User session expired", "Login again to continue", "Ok");
                    await Shell.Current.GoToAsync(nameof(LoginPage));
                }
                else
                {
                    var userInfo = JsonConvert.DeserializeObject<UserLoginInfo>(userLoginInfo);
                    App.UserLoginInfo = userInfo;
                    App.Token = tokenDetail;
                    await Shell.Current.GoToAsync("//MainPage");
                }
            }

        }
    }
}
