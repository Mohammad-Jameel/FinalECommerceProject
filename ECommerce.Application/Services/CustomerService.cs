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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task BanTheCustomer(int id)
        {
            await _customerRepository.BanTheCustomer(id);
        }

        public async Task<List<GetAllCustomers>> GetAllCustomersAsync()
        {
            var result=await _customerRepository.GetAllCustomersAsync();
            return result;
        }

        public async Task<List<GetAllCustomerOrders>> GetAllCustomersOrdersAsync(int id)
        {
            var result = await _customerRepository.GetAllCustomersOrdersAsync(id);
            return result;
        }

        public async Task<List<GetOrderDetails>> GetTheOrderDetails(int id)
        {
            var result=await _customerRepository.GetTheOrderDetails(id);
            return result;
        }
    }
}
