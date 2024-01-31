using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Queries
{
    public static class UserQuery
{
        public const string AddUser = "dbo.AddUser";
        public const string ChangeUsrPassword = "dbo.ChangeUserPassword";
        public const string GetAllUser = "dbo.GetAllUser";
        public const string LoginUser = "dbo.LoginUser";
        public const string LastLogin = "dbo.LastLogin";
    }
}
