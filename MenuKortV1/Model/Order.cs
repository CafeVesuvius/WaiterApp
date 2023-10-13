using Newtonsoft.Json;

namespace MenuKortV1.Model
{
    public class Order
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonProperty("orderLines")]
        public virtual List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
