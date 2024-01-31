using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Order
    {
        public int CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderStatus { get; set; }
        public int Id { get; set; }
        public string CustomerNotes { get; set; }
        public int Feedback { get; set; }
    }
}
