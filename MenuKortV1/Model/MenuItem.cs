using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnitPrice { get; set; }
        public bool Active { get; set; }
        public int MenuID { get; set; }
    }
}
