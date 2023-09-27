using MenuKortV1.Model;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MenuKortV1.Data
{
    public static class APIAccess
    {
        // Define a variable to store the API adress
        static readonly string ApiBaseUrl = "http://10.130.54.74:2000";

        //key string
        static readonly string Key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJDVl9BZG1pbiIsIm5iZiI6MTY5NTczMTE1MCwiZXhwIjoxNjk1ODE3NTUwLCJpYXQiOjE2OTU3MzExNTB9.pv5lMjckC_yIXpYagm5p2fA-0li88geqxZdqNKkGl3g";

        // Define API token
        private static readonly string AuthorizationToken = Key;

        // Define a http client
        static HttpClient Client = new HttpClient();

        // Define serializer
        static JsonSerializerOptions serializerOptions;

        // Set up the http connection to the API
        static APIAccess()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.BaseAddress = new Uri(ApiBaseUrl);


            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        // http response
        //static HttpResponseMessage APIResponse;

        // Get json string and deserialize it
        public static async Task<Menu> GetMenu()
        {
            try
            {
                HttpResponseMessage APIResponse = new HttpResponseMessage();
                APIResponse = await Client.GetAsync($"{ApiBaseUrl}/api/menu");
                APIResponse.EnsureSuccessStatusCode();
                string responseBody = await APIResponse.Content.ReadAsStringAsync();
                Menu menus = JsonConvert.DeserializeObject<Menu>(responseBody);
                return menus;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Post order
        public static async Task<bool> OrderPoster(Order o)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize<Order>(o, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage APIResponse = new HttpResponseMessage();
                APIResponse = await Client.PostAsync($"{ApiBaseUrl}/api/order", content);
                APIResponse.EnsureSuccessStatusCode();
                //string bing = Client.DefaultRequestHeaders.ToString();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}