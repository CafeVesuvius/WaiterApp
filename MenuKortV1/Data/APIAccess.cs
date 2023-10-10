using MenuKortV1.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MenuKortV1.Data
{
    public static class APIAccess
    {
        // Define a variable to store the API adress
        static readonly string ApiBaseUrl = "http://10.130.54.74:2000";

        //key string
        //static readonly string Key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJDVl9BZG1pbiIsIm5iZiI6MTY5NjgzMTcxNSwiZXhwIjoxNjk2OTE4MTE1LCJpYXQiOjE2OTY4MzE3MTV9.NMxbZawiSDFgO7o-Ju4hK5AtVeVbd27FWRb7q39qSRQ";

        // Define API token
        //private static string AuthorizationToken;

        //booly bool
        //public static bool Authorized = false;

        // Define a http client
        static HttpClient Client = new HttpClient();

        // Define serializer
        static JsonSerializerOptions serializerOptions;

        // Set up the http connection to the API
        static APIAccess()
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.BaseAddress = new Uri(ApiBaseUrl);

            

            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        // Get request for "api/menu"
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
            catch
            {
                return null;
            }
        }

        // Get request for the current order via id
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

        // Post request for "api/order"
        public static async Task<bool> OrderPoster(Order o)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize<Order>(o, serializerOptions);
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

        // Delete request for "api/order/{id}"
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

        // Post request for "api/order/orderLine"
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