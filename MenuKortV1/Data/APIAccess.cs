using MenuKortV1.Model;
using Newtonsoft.Json;

namespace MenuKortV1.Data
{
    public static class APIAccess
    {
        // Define a variable to store the API adress
        static readonly string ApiBaseUrl = "http://10.130.54.74:2000/";

        // Define a http client
        static readonly HttpClient client;

        // Set up the http connection to the API
        static APIAccess()
        {
            client = new HttpClient() { BaseAddress = new Uri(ApiBaseUrl) };
        }

        // Get json string and deserialize it
        public static async Task<Menu> GetMenu()
        {
            var json = await client.GetStringAsync(ApiBaseUrl+"api/menu");
            var menus = JsonConvert.DeserializeObject<Menu>(json);
            return menus;
        }
    }
}