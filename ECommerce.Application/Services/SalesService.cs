using Core.Entity;
using Core.IAdminService;
using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository sales;

        public SalesService(ISalesRepository sales)
        {
            this.sales = sales;
        }

        public async Task<List<PercentageOfConfirmedOrders>> GetConfirmedOrders()
        {
            var result =await sales.GetConfirmedOrders();
            return result;
        }

        public async Task<List<DeliveredOrdersForLastMonth>> GetDeliveredOrdersForLastMonth()
        {
           var result=await sales.GetDeliveredOrdersForLastMonth();
            return result;
        }

        public Task<List<DeliveredOrdersForLastYear>> GetDeliveredOrdersForLastYear()
        {
            var result= sales.GetDeliveredOrdersForLastYear();
            return result;
        }

        public async Task<List<LastThrtyDaysSales>> GetLastThrtyDaysSales()
        {
            var result=await sales.GetLastThrtyDaysSales();
            return result;
        }

        public async Task<List<MonthlySales>> GetMonthlySales()
        {
            var result=await sales.GetMonthlySales();
            return result;
        }

        public async Task<List<PercentageOfNewOrders>> GetNewOrders()
        {
            var result= await sales.GetNewOrders();
            return result;
        }
    }
}
