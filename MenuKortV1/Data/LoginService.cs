using MenuKortV1.Model;
using Newtonsoft.Json;
using System.Text;

namespace MenuKortV1.Data
{
    public class LoginService : ILoginService
    {
        public async Task<LoginResponse> Authenticate(LoginRequest loginRequest)
        {
            using (var client = new HttpClient())
            {
                string loginRequestJson = JsonConvert.SerializeObject(loginRequest);
                var response = client.PostAsync("http://10.130.54.74:2000/api/Authentication", new StringContent(loginRequestJson, Encoding.UTF8, "application/json"));

                if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Result.Content.ReadAsStringAsync();
                    return new LoginResponse
                    {
                        Token = json,
                    };
                }
                else { return null; }
            }
        }
    }
}
