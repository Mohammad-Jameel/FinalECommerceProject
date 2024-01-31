using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICustomerRepository
    {
        Task<List<GetAllCustomers>> GetAllCustomersAsync();
        Task BanTheCustomer(int id);
        Task<List<GetAllCustomerOrders>> GetAllCustomersOrdersAsync(int id);
        Task<List<GetOrderDetails>> GetTheOrderDetails(int id);
    }
}
