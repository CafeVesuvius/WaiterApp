using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public bool Active { get; set; }
        public DateTime Changed_TS { get; set; }
    }
}
