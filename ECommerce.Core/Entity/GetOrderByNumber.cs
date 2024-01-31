using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class GetOrderByNumber
    {
        public int Id { get; set; }
        public double NetPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Phone { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CustomerNotes { get; set; }
        public int Feedback { get; set; }
    }
}
