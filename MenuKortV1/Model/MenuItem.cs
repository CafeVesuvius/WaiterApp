using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace MenuKortV1.Model
{
    public partial class MenuItem : ObservableObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("unitPrice")]
        public string UnitPrice { get; set; }

        [JsonProperty("isActive")]
        public bool Active { get; set; }

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }

        [JsonProperty("menuId")]
        public int MenuID { get; set; }

        // These two variables are only used within the app
        [ObservableProperty]
        public byte quantity;

        [ObservableProperty]
        public string detail;
    }
}
