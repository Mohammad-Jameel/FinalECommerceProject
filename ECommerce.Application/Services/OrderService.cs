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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CanceTheOrder(int id)
        {
            await _orderRepository.CanceTheOrder(id);
        }

        public async Task ConfirmedTheOrder(int id)
        {
            await _orderRepository.ConfirmedTheOrder(id);
        }

        public async Task DeliveredTheOrder(int id)
        {
            await _orderRepository.DeliveredTheOrder(id);
        }

        public async Task<List<GetOrderByNumber>> GetOrderByNumbers(int id)
        {
            var result= await _orderRepository.GetOrderByNumbers(id);
            return result;
        }

        public async Task<List<GetOrderDetails>> GetOrderDetails(int id)
        {
            var result=await _orderRepository.GetOrderDetails(id);
            return result;
        }

        public async Task<List<GetAllOrders>> GettAllOrders()
        {
            var result= await _orderRepository.GettAllOrders();
            return result;
        }

        public async Task RemoveItems(RemoveItmes removeItmes)
        {
            await _orderRepository.RemoveItems(removeItmes);
        }
    }
}
