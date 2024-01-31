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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connectionstring;
        private readonly IConfiguration _configuration;

        public CategoryRepository( IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DBConnection");

        }

        public async Task<int> AddNewCategory(Categories category)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(CategoryQuery.AddNewCategory, new {TaxPercentage=category.TaxPercentage,name=category.Name,description=category.Description }, commandType: System.Data.CommandType.StoredProcedure);
                return category.Id;
            }
            }

        public async Task DeleteCategory(int Id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(CategoryQuery.DeleteCategory, new {id=Id},commandType:System.Data.CommandType.StoredProcedure);
            }
            }

        public async Task<List<GetAllCategories>> GetAllCategories()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetAllCategories>(CategoryQuery.GetAllCategories, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            }

        public async Task UpdateCategory(Categories categories)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(CategoryQuery.UpdateCategory, new { id = categories.Id,name=categories.Name,description=categories.Description,taxpercentage=categories.TaxPercentage }, commandType: System.Data.CommandType.StoredProcedure);
            }
            }
    }
}
