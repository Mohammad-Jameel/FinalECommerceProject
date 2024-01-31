using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Queries
{
    public static class OrderQuery
    {
        public const string CancelTheOrder = "dbo.CancelTheOrder";
        public const string ConfirmedTheOrder = "dbo.ConfirmedTheOrder";
        public const string DeliveredTheOrder = "dbo.DeliverdTheOrder";
        public const string GetOrderDetails = "dbo.GetOrderDetails";
        public const string GetAllOrders = "dbo.GetAllOrders";
        public const string RemoveItem = "dbo.RemoveItems";
        public const string GetOrderByNumber = "dbo.GetOrderByNumber";
    }
}
