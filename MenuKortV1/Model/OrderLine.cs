using Newtonsoft.Json;

namespace MenuKortV1.Model
{
    public class OrderLine
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("quantity")]
        public byte Quantity { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("menuItemID")]
        public int MenuItemID { get; set; }

        [JsonProperty("orderID")]
        public int OrderID { get; set; }
    }
}
