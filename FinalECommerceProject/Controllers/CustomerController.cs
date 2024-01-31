using Core.IAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CustomerController : ControllerBase
    { private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [Authorize(Roles ="Admin ,MainAdmin")]
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var res=await _customerService.GetAllCustomersAsync();
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("BanCustomers/{id}")]
        public async Task<IActionResult>BanTheCustomer(int id)
        {
            await _customerService.BanTheCustomer(id);
            return Ok();
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetCustomerOrders/{id}")]
        public async Task<IActionResult> GetCustomerOrders(int id) {
            var res = await _customerService.GetAllCustomersOrdersAsync(id);
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetOrderDetails/{id}")]
        public async Task<IActionResult>GetOrderDetails(int id)
        {
            var res=await _customerService.GetTheOrderDetails(id);
            return Ok(res);
        }



    }
}
