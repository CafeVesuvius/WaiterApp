using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class MenuItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("unitPrice")]
        public string UnitPrice { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("menuId")]
        public int MenuID { get; set; }
    }
}
