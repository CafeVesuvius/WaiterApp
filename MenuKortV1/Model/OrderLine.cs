using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class OrderLine
    {
        public int Id { get; set; }

        public byte Quantity { get; set; }

        public string Detail { get; set; } = null!;

        public int MenuItemID { get; set; }

        public int OrderID { get; set; }
    }
}
