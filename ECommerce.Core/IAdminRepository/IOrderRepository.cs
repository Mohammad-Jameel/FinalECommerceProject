using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IOrderRepository
    {
        Task<List<GetAllOrders>> GettAllOrders();
        Task<List<GetOrderDetails>> GetOrderDetails(int id);
        Task<List<GetOrderByNumber>>GetOrderByNumbers(int id);
        Task RemoveItems(RemoveItmes removeItmes);
        Task CanceTheOrder(int id);
        Task DeliveredTheOrder(int id);
        Task ConfirmedTheOrder(int id);
    }
}
