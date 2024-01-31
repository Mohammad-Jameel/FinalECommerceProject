using Core.Entity;
using Core.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly string connectionstring;
        private readonly IConfiguration _configuration;

        public RolesRepository( IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DBConnection");
        }
        public async Task<List<Roles>> GetRoles()
        { 
            using(var connection=new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<Roles>("dbo.GetAllRoles", commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
