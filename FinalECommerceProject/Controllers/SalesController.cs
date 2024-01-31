using Core.IAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace FinalECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService sales;

        public SalesController(ISalesService sales)
        {
            this.sales = sales;
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetConfirmedOrders")]
        public async Task<IActionResult> ConfirmedOrders() { 
            var res= await sales.GetConfirmedOrders();
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetDeliveredOrderForLastMonth")]
        public async Task<IActionResult> GetDeliveredOrderForLastMonth() { 
        var res=await sales.GetDeliveredOrdersForLastMonth();
            return Ok(res);
        }

        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetDeliveredOrderForLastYear")]
        public async Task<IActionResult> GetDeliveredOrderForLastYear() {
        var res=await sales.GetDeliveredOrdersForLastYear();
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetLastThrtyDaysSales")]
        public async Task<IActionResult> LastThrtyDaysSales() {
            var res = await sales.GetLastThrtyDaysSales();
            return Ok(res);
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetMonthlySales")]
        public async Task<IActionResult> GetMonthlySales() { 
        var res= await sales.GetMonthlySales();
            return Ok(res);


        }

        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpGet("GetNewOrder")]
        public async Task<IActionResult> GetNewOrder()
        {
            var res = await sales.GetNewOrders();
            return Ok(res);

        }
    }
}
