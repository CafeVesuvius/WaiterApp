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
                // Get login credentials from login request
                string loginRequestJson = JsonConvert.SerializeObject(loginRequest);

                // Attempt to get new token at the "Authentication" API endpoint
                var response = client.PostAsync("http://10.130.54.46:2000/api/Authentication", new StringContent(loginRequestJson, Encoding.UTF8, "application/json"));

                // If login is successful, save token in persistent data
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
