﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class Menu
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("changed")]
        public DateTime Changed_TS { get; set; }

        [JsonProperty("menuItems")]
        public List<MenuItem> Items { get; set; }
    }
}
