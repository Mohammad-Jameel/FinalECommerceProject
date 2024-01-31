using Core.Entity;
using Core.IAdminService;
using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RolesService : IRoleService
    {
        private readonly IRolesRepository rol;

        public RolesService(IRolesRepository rol)
        {
            this.rol = rol;
        }

        public async Task<List<Roles>> GetRoles()
        {
            var result= await this.rol.GetRoles();
            return result;
        }
    }
}
