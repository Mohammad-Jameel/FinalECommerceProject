using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ISalesRepository
    {
        Task<List<DeliveredOrdersForLastMonth>> GetDeliveredOrdersForLastMonth();
        Task<List<DeliveredOrdersForLastYear>> GetDeliveredOrdersForLastYear();
        Task<List<LastThrtyDaysSales>> GetLastThrtyDaysSales();
        Task<List<MonthlySales>> GetMonthlySales();
        Task<List<PercentageOfConfirmedOrders>> GetConfirmedOrders();
        Task<List<PercentageOfNewOrders>> GetNewOrders();
    }
}
