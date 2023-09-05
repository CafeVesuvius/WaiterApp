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

        public string placeholderData = "{\r\n  \"Menu\": {\r\n    \"Burger\":{\r\n      \"Price\":130,\r\n      \"Description\":\"TEST TEST TEST\"\r\n    },\r\n    \"Pizza\":{\r\n      \"Price\": 85,\r\n      \"Description\":\"Good Peperoni Pizza\"\r\n    }\r\n  }\r\n}";


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

        public List<Menu> GetMenusAsync()
        {
            Menus = new List<Menu>();

            var json = placeholderData;
            var jsonConverted = JsonConvert.DeserializeObject<List<Menu>>(json);
            return jsonConverted.ToList();
        }
    }
}