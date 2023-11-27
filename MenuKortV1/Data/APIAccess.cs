using MenuKortV1.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MenuKortV1.Data
{
    public static class APIAccess
    {
        // Define a variable to store the API adress
        static readonly string ApiBaseUrl = "http://10.130.54.23:2000";

        // Define a http client
        static readonly HttpClient Client = new HttpClient();

        // Set up the http connection to the API
        static APIAccess()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.BaseAddress = new Uri(ApiBaseUrl);
        }

        // Get request for "api/menu/active" endpoint
        public static async Task<List<Menu>> GetMenu()
        {
            try
            {
                HttpResponseMessage APIResponse = new HttpResponseMessage();
                APIResponse = await Client.GetAsync($"{ApiBaseUrl}/api/menu/active");
                APIResponse.EnsureSuccessStatusCode();
                string responseBody = await APIResponse.Content.ReadAsStringAsync();
                List<Menu> menus = JsonConvert.DeserializeObject<List<Menu>>(responseBody);
                return menus.ToList();
            }
            catch
            {
                return null;
            }
        }

        // Get request for "api/order/incomplete" endpoint
        public static async Task<int> GetOrderId(Order o)
        {
            HttpResponseMessage APIResponse = new HttpResponseMessage();
            APIResponse = await Client.GetAsync($"{ApiBaseUrl}/api/order/incomplete");
            APIResponse.EnsureSuccessStatusCode();
            string responseBody = await APIResponse.Content.ReadAsStringAsync();

            List<Order> allOrders = JsonConvert.DeserializeObject<List<Order>>(responseBody);

            int idCatcher = 0;

            foreach ( Order order in allOrders )
            {
                if(order.Name == o.Name)
                {
                    idCatcher = order.Id;
                    break;
                }
            }
            return idCatcher;
        }

        // Post request for "api/order" endpoint
        public static async Task<bool> OrderPoster(Order o)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize<Order>(o);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage APIResponse = new HttpResponseMessage();
                APIResponse = await Client.PostAsync($"{ApiBaseUrl}/api/order", content);
                APIResponse.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete request for "api/order/{id}" endpoint
        public static async Task<bool> OrderDeleter(Order o)
        {
            try
            {
                HttpResponseMessage APIResponse = new HttpResponseMessage();
                APIResponse = await Client.DeleteAsync($"{ApiBaseUrl}/api/order/{o.Id}");
                APIResponse.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Post request for "api/order/orderLine" endpoint
        public static async Task<string> OrderLinePoster(OrderLine ol) 
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize<OrderLine>(ol);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage APIResponse = new HttpResponseMessage();
                APIResponse = await Client.PostAsync($"{ApiBaseUrl}/api/order/orderLine", content);
                APIResponse.EnsureSuccessStatusCode();
                string str = APIResponse.ToString();
                return str;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}