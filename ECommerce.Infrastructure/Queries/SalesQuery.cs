using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Queries
{
    public static class SalesQuery
    {
        public const string PercentageConfirmed =     "dbo.PercentageOfConfirmedOrders";
                                                       
        public const string PercentageNew =           "dbo.PercentageOfNewOrders";
        public const string YearlySales =             "dbo.MonthlySales";
        public const string MonthlySales =            "dbo.LastThertyDaysSales";
        public const string DeliverdOrdersLastYear =  "dbo.DeliveredOrdersForLastYear";
        public const string DeliverdOrdersLastMonth = "dbo.DeliveredOrdersForLastMonth";
    }
}
