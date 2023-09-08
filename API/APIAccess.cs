using API.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API
{
    public class APIAccess
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<Menu> Menus { get; private set; }
        static string BaseUrl = "";


        public APIAccess()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Menu>> GetMenusAsync()
        {
            Menus = new List<Menu>();

            var json = await _client.GetStringAsync("http://10.130.54.74:2000/api/menu");
            var jsonConverted = JsonConvert.DeserializeObject<List<Menu>>(json);
            return jsonConverted.ToList();
        }
    }
}