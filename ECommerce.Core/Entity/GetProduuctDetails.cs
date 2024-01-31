using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
   public class GetProduuctDetails
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Availability { get; set; }

        public float Price { get; set; }
        public string? Image1 { get; set; }
        public string? Image3 { get; set; }
        public string? Image2 { get; set; }
        public string? Image4 { get; set;
        }
    }
}
