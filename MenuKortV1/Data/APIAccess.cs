using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MenuKortV1.Data
{
    public class APIAccess
    {
        static readonly string BaseAddress = "http://10.130.54.74:2000";
        static readonly string Url = $"{BaseAddress}/api";

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<Model.Menu> Menus { get; private set; }
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

        public async Task<List<Model.Menu>> GetMenusAsync()
        {
            Menus = new List<Model.Menu>();

            var json = await _client.GetStringAsync($"{Url}/menu");
            var jsonConverted = JsonConvert.DeserializeObject<List<Model.Menu>>(json);
            return jsonConverted.ToList();
        }
    }
}
