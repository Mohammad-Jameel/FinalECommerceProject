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
    public class BrandRepository : IBrandRepository
    {
        private readonly string connectionstring;
        private readonly IConfiguration configuration;

        public BrandRepository( IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DBConnection");
            
        }

        public async Task<int> AddNewBrand(Brands brands)
        {
           using(var connection=new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(BrandQuery.AddBrand, new {brand=brands.Brand},commandType:System.Data.CommandType.StoredProcedure);
                return brands.Id;
            }
        }

        public async Task DeleteBrand(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync("dbo.DeleteBrand", new { id=id }, commandType: System.Data.CommandType.StoredProcedure);
               
            }
        }

        public async Task<List<Brands>> GetAllBrandsAsync()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<Brands>(BrandQuery.GetAllBrands,commandType:System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            }

        public async Task UpdateBrand(Brands brands)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(BrandQuery.UpdateBrand, new{brand=brands.Brand,id=brands.Id },commandType:System.Data.CommandType.StoredProcedure);
                
            }
            }
    }
}
