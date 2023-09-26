using MenuKortV1.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MenuKortV1.Data
{
    public static class APIAccess
    {
        // Define a variable to store the API adress
        static readonly string ApiBaseUrl = "http://10.130.54.74:2000";

        // Define API token
        private static string AuthorizationToken = "test";

        // Define a http client
        static readonly HttpClient client;

        // Set up the http connection to the API
        static APIAccess()
        {
            client = new HttpClient() { BaseAddress = new Uri(ApiBaseUrl) };
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("dotnetconfstudentzone", AuthorizationToken);
        }

        // Get json string and deserialize it
        public static async Task<Menu> GetMenu()
        {
            var json = await client.GetStringAsync(ApiBaseUrl+"/api/menu");
            var menus = JsonConvert.DeserializeObject<Menu>(json);
            return menus;
        }

        // Serialise
        public static async Task<Order> OrderPoster()
        {
            return null;
        }
    }
}