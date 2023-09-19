using MenuKortV1.Model;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MenuItem = MenuKortV1.Model.MenuItem;

namespace MenuKortV1.Data
{
    public static class APIAccess
    {
        static readonly string ApiBaseUrl = "http://10.130.54.74:2000/";
        static readonly HttpClient client;

        static APIAccess()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
        }

        public static async Task<Menu> GetMenu()
        {
            var json = await client.GetStringAsync(ApiBaseUrl+"api/menu");
            var menus = JsonConvert.DeserializeObject<Menu>(json);
            return menus;
        }
    }
}
//https://www.youtube.com/watch?v=a37qBMt0V9w&ab_channel=JamesMontemagno