using Core.Entity;
using Core.Interface;
using Dapper;
using ECommerce.Core.Entity;
using ECommerce.Infrastructure.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public UserRepository(IConfiguration configuration)
        {this._configuration = configuration;
            this.connectionstring = configuration.GetConnectionString("DBConnection");
        }

        public async Task<int> AddUser(AddUser adduser)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(UserQuery.AddUser, new
                {
                    firstName = adduser.FirstName,
                    lastName = adduser.LastName,
                    address = adduser.Address,
                    email = adduser.Email
                ,
                    password = adduser.Password,
                    phone = adduser.Phone,
                    role = adduser.Role
                }
                , commandType: System.Data.CommandType.StoredProcedure);
                return adduser.Id;
            }
        }

        public async Task<string> ChangeUserPassword(LoginUser user)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(UserQuery.ChangeUsrPassword,
                    new { email = user.Email, password = user.Password }, commandType: System.Data.CommandType.StoredProcedure);
                return user.Password;
            }
        }

        public async Task<List<GetAllUsers>> GetAllAsync()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetAllUsers>("dbo.GetAllUsers", commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<string> Login(LoginUser loginuser)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var user = await connection.QueryAsync<User>(UserQuery.LoginUser,
                     new { email = loginuser.Email, password = loginuser.Password }, commandType: System.Data.CommandType.StoredProcedure);
                


                LastLogin(loginuser);
                return GenerateJwtToken(user.First().Role,(user.First().FirstName+" " +user.First().LastName),user.First().Id);
            }
        }
        public async Task LastLogin(LoginUser login)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(UserQuery.LastLogin,
                     new { email = login.Email}, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        private string GenerateJwtToken(string theRole,string name,int id)
        {
            var key = _configuration.GetValue<string>("JWT:Secret");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var calims = new List<Claim>();
            
           
            calims.Add(new Claim(ClaimTypes.Role, theRole));
            calims.Add(new Claim(ClaimTypes.Name, name));
            calims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            var identity = new ClaimsIdentity(calims, "MyAuthenticationScheme");

            var principal = new ClaimsPrincipal(identity);




            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (_configuration.GetValue<string>("JWT:ValidIssuer"),
                _configuration.GetValue<string>("JWT:ValidAudience"),
                expires: DateTime.Now.AddHours(72),
                signingCredentials: credentials,
                claims: calims


                ) ;

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        public async Task BanTheUser(int id) {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(CustomerQuery.BanTheCustome,
                    new {id=id }, commandType: System.Data.CommandType.StoredProcedure);
                
            }
        }

        public async Task UpdateUser(UpdateUser updateUser)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync("dbo.UpdateUser", new
                {
                    firstName = updateUser.FirstName,
                    lastName = updateUser.LastName,
                    address = updateUser.Address,
                    email = updateUser.Email
                ,
                    password = updateUser.Password,
                    phone = updateUser.Phone,
                    role = updateUser.Role,id= updateUser.Id,activation= updateUser.Activation
                }
                , commandType: System.Data.CommandType.StoredProcedure);
               
            }

        }

        public async Task UpdateCustomer(SignUp signUp)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync("dbo.UpdateCustomer", new
                {
                    firstName = signUp.FirstName,
                    lastName = signUp.LastName,
                    address = signUp.Address,
                    email = signUp.Email,
                    phone=signUp.phone,
                    password=signUp.Password,
                     id = signUp.Id
                }
                , commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}