using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Season { get; set; }
        public bool Active { get; set; }
        public DateTime? Changed_TS { get; set; }
    }
}
