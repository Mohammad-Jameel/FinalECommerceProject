using Core.Entity;
using Core.Interface;
using Dapper;
using ECommerce.Infrastructure.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connectionstring;
        private readonly IConfiguration _configuration;

        public OrderRepository(IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DBConnection");
        }
        public async Task CanceTheOrder(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(OrderQuery.CancelTheOrder, new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task ConfirmedTheOrder(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(OrderQuery.ConfirmedTheOrder, new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task DeliveredTheOrder(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(OrderQuery.DeliveredTheOrder, new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<List<GetOrderByNumber>> GetOrderByNumbers(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetOrderByNumber>(OrderQuery.GetOrderByNumber, new { id = id }, commandType: System.Data.CommandType.StoredProcedure);
                return result.AsList();
            }

        }

        public async Task<List<GetOrderDetails>> GetOrderDetails(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetOrderDetails>(OrderQuery.GetOrderDetails, new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task<List<GetAllOrders>> GettAllOrders()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetAllOrders>(OrderQuery.GetAllOrders, commandType: System.Data.CommandType.StoredProcedure);
                return result.AsList();
            }
        }

        public async Task RemoveItems(RemoveItmes removeItmes)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync(OrderQuery.RemoveItem, new { orderid = removeItmes.OrderId, productid = removeItmes.ProductId }, commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
