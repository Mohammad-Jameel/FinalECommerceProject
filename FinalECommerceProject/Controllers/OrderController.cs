using Core.Entity;
using Core.IAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService order;

        public OrderController(IOrderService order)
        {
            this.order = order;
        }
        [Authorize(Roles = "Admin ,MainAdmin,Customer")]
        [HttpGet("CancelTheOrder/{id}")]
        public async Task<IActionResult>CancelTheOrder(int id)
        {
            await order.CanceTheOrder(id);
            return Ok();
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("ConfirmTheOrder/{id}")]
        public async Task<IActionResult>ConfirmTheOrder(int id)
        {
            await order.ConfirmedTheOrder(id); return Ok();
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("DeliverTheOrder/{id}")]
        public async Task <IActionResult> DeliverTheOrder(int id)
        {
            await order.DeliveredTheOrder(id);
            return Ok();
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetOrderByNumber/{id}")]
        public async Task<IActionResult> GetOrderByNumber(int id)
        {
            var res= await order.GetOrderByNumbers(id);
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetOrderDetails/{id}")]
        public async Task<IActionResult>GetOrderDetails(int id)
        {
            var res=await order.GetOrderDetails(id);
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrders() {
            var res = await order.GettAllOrders();
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("RemoveItem")]
        public async Task<IActionResult> RemoveItem(RemoveItmes remove) { 
        await order.RemoveItems(remove);
            return Ok();
        }


    }
}
