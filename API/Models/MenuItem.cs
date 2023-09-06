using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }   
        public required string UnitPrice { get; set; }
        public bool Active { get; set; }
    }
}
