using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class GetAllCustomerOrders
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float NetPrice { get; set; }

    }
}
