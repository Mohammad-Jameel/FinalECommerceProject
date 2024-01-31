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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string connectionstring;
        private readonly IConfiguration _configuration;

        public CustomerRepository( IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DBConnection");
        }

        public async Task BanTheCustomer(int id)
        {
            using(var connection=new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(CustomerQuery.BanTheCustome, new {Id= id},commandType:System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<List<GetAllCustomers>> GetAllCustomersAsync()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetAllCustomers>(CustomerQuery.GetAllCustomers,commandType:System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            }

        public async Task<List<GetAllCustomerOrders>> GetAllCustomersOrdersAsync(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetAllCustomerOrders>(CustomerQuery.GetCustomerOrders, new {Id=id},commandType:System.Data.CommandType.StoredProcedure);
                return result.ToList(); 
            }
            }

        public async Task<List<GetOrderDetails>> GetTheOrderDetails(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetOrderDetails>(CustomerQuery.GetOrderDetails, new { Id=id},commandType:System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            }
    }
}
