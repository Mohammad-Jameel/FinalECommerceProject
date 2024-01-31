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
    public class SalesRepository : ISalesRepository
    {

        private readonly string connectionstring;
        private readonly IConfiguration _configuration;

        public SalesRepository( IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DBConnection");
        }
        public async Task<List<PercentageOfConfirmedOrders>> GetConfirmedOrders()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<PercentageOfConfirmedOrders>(SalesQuery.PercentageConfirmed, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            }

        public async Task<List<DeliveredOrdersForLastMonth>> GetDeliveredOrdersForLastMonth()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<DeliveredOrdersForLastMonth>(SalesQuery.DeliverdOrdersLastMonth, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();

            }
            }

        public async Task<List<DeliveredOrdersForLastYear>> GetDeliveredOrdersForLastYear()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<DeliveredOrdersForLastYear>(SalesQuery.DeliverdOrdersLastYear, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();

            }
        }

        public async Task<List<LastThrtyDaysSales>> GetLastThrtyDaysSales()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<LastThrtyDaysSales>(SalesQuery.MonthlySales, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();

            }

        }

        public async Task<List<MonthlySales>> GetMonthlySales()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<MonthlySales>(SalesQuery.YearlySales, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();

            }
        }

        public async Task<List<PercentageOfNewOrders>> GetNewOrders()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<PercentageOfNewOrders>(SalesQuery.PercentageNew, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();

            }
        }
    }
}
