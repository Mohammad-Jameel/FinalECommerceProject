using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Queries
{
    public static class CustomerQuery
{
        public const string BanTheCustome = "dbo.BanTheCustomer";
        public const string GetAllCustomers = "dbo.GetAllCustomers";
        public const string GetCustomerOrders = "dbo.GetAllCustomerOrders";
        public const string GetOrderDetails = "dbo.GetOrderDetails";
}
}
