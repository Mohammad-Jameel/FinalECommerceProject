using Core.Entity;
using ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IUserRepository
    {
        Task<List<GetAllUsers>> GetAllAsync();
        Task<int> AddUser(AddUser adduser);
        Task<string> ChangeUserPassword(LoginUser loginuser);
        Task<string>Login(LoginUser loginuser);
        Task BanTheUser(int id);
        Task UpdateUser(UpdateUser updateUser);
        Task UpdateCustomer(SignUp signUp);

    }
}
