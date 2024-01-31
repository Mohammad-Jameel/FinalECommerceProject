using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public int BrandId { get; set; }

        public int Quantity { get; set; }
        public float Price { get; set; }
        public int AvailabilityId { get; set; }
    }
}
