using Core.Entity;
using Core.IAdminService;
using Core.Interface;
using ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository users;

        public UserService(IUserRepository user)
        {
            this.users = user;
        }

        public async Task<int> AddUser(AddUser adduser)
        {
            var result=await users.AddUser(adduser);
            return result;
        }

        public async Task<string> ChangeUserPassword(LoginUser user)
        {
            var result=await users.ChangeUserPassword(user);
            return result;
        }

        public async Task<List<GetAllUsers>> GetAllAsync()
        {
            var result=await users.GetAllAsync();
            return result;
        }

        public async Task<string> Login(LoginUser loginuser)
        {
            var result= await users.Login(loginuser);
            return result;
        }

       

        public async Task BanTheUser(int id)
        {
           await users.BanTheUser(id);
        }

        public async Task UpdateUser(UpdateUser updateUser)
        {
            await users.UpdateUser(updateUser);
        }

        public async Task UpdateCustomer(SignUp signUp)
        {
            await users.UpdateCustomer(signUp);
        }
    }
}
