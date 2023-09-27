﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class Order
    {
        //[JsonProperty("id")]
        //public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonProperty("orderLines")]
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
