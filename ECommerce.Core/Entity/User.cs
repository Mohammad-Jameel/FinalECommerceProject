using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public double Phone { get; set; }
        
        public string Address { get; set; }
        public int Activation { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int RoleId { get; set; }
    }
}
