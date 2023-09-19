using MenuKortV1.Model;
using Newtonsoft.Json;

namespace MenuKortV1.Data
{
    public static class APIAccess
    {
        static readonly string ApiBaseUrl = "http://10.130.54.74:2000/";
        static readonly HttpClient client;

        static APIAccess()
        {
            client = new HttpClient() { BaseAddress = new Uri(ApiBaseUrl) };
        }

        public static async Task<Menu> GetMenu()
        {
            var json = await client.GetStringAsync(ApiBaseUrl+"api/menu");
            var menus = JsonConvert.DeserializeObject<Menu>(json);
            return menus;
        }
    }
}