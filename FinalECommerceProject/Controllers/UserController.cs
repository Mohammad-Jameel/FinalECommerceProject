using Core.Entity;
using Core.IAdminService;
using ECommerce.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService user;

        public UserController(IUserService user)
        {
            this.user = user;
        }
        [Authorize(Roles = "MainAdmin")]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUser adduser) { 
        
       var res= await  user.AddUser(adduser);
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin,Customer")]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangeUserPassword(LoginUser login) { 
        await user.ChangeUserPassword(login);
            return Ok();
        
        }
        [Authorize(Roles = "MainAdmin")]
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser() { 
        
        var res=await user.GetAllAsync();
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult>Login(LoginUser login)
        {
            var token= await user.Login(login);
            if (token == null) { return BadRequest(); }
            else { return Ok(token); }
        }

        [Authorize(Roles = "MainAdmin")]
        [HttpGet("BanTheUser/{id}")]
        public async Task<IActionResult> BanUser(int id) { 
        
        await user.BanTheUser(id);
            return Ok();
        }
        [Authorize(Roles = "MainAdmin")]
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUser updateUser) { 
        await user.UpdateUser(updateUser);
            return Ok();
        
        }
        [Authorize(Roles ="Customer")]
        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult>UpdateCustomerData(SignUp signUp)
        {

            await user.UpdateCustomer(signUp);
            return Ok();
        }
    }
}
