using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuKortV1.Model
{
    public class Order
    {
        //public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? CreatedDate { get; set; }

        public bool IsCompleted { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
