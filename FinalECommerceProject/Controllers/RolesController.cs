using Core.IAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService role;

        public RolesController(IRoleService role)
        {
            this.role = role;
        }
        [Authorize(Roles = "MainAdmin")]
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetTheRoles() {
            var res = await role.GetRoles();
            return Ok(res);
        }
    }
}
