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
        static readonly string Key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJDVl9BZG1pbiIsIm5iZiI6MTY5NTcxODUyMSwiZXhwIjoxNjk1ODA0OTIxLCJpYXQiOjE2OTU3MTg1MjF9.d8aAnxU5nZNj717X-IzDfkXP7q9a27I1NamPMdfcsko";

        // Define API token
        private static readonly string AuthorizationToken = Key;

        // Define a http client
        static HttpClient Client = new HttpClient();

        // Define serializer
        static JsonSerializerOptions serializerOptions;

        // Set up the http connection to the API
        static APIAccess()
        {
            Client.DefaultRequestHeaders.Add("Authorization", AuthorizationToken);
            Client.DefaultRequestHeaders.Add("Accept", "application/json");

            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        // http response
        static HttpResponseMessage APIResponse;

        // Get json string and deserialize it
        public static async Task<Menu> GetMenu()
        {
            try
            {
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

        // Serialise
        public static async Task<string> OrderPoster(Order o)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize<Order>(o, serializerOptions);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                APIResponse = await Client.PostAsync($"{ApiBaseUrl}/api/order/all", content);

                return ":3";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            //var msg = new HttpRequestMessage(HttpMethod.Post, $"{ApiBaseUrl}/api/orders");
            //msg.Content = JsonContent.Create<Order>(o);
            //var response = await Client.SendAsync(msg);
            //response.EnsureSuccessStatusCode();
            //var itemJson = await response.Content.ReadAsStringAsync();
            //var insertedOrder = System.Text.Json.JsonSerializer.Deserialize<Order>(itemJson);
            //return insertedOrder;
        }
    }
}