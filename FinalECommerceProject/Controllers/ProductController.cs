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
    public class ProductController : ControllerBase
    {
        private readonly IProductService product;

        public ProductController(IProductService product)
        {
            this.product = product;
        }
        [Authorize(Roles = ("Admin ,MainAdmin"))]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddNewProduct newProduct) { 
            var res=await product.AddNewProduct(newProduct);
            return Ok(res);
        }
        [Authorize(Roles = ("Admin ,MainAdmin"))]
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            await product.DeleteProduct(id);
            return Ok();
        }
        [Authorize(Roles = ("Admin ,MainAdmin"))]
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct() { 
        var res=await product.GetAllProducts();
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("GetAllCustomerProducts")]
        public async Task<IActionResult> GetCustomerProducts()
        {
            var res=await product.GetCustomerProducts();    
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("GetProductDetails/{id}")]
        public async Task<IActionResult>GetProductDetails(int id)
        {
            var res=await product.GetProduuctDetails(id);
            return Ok(res);
        }
        [Authorize(Roles = ("Admin ,MainAdmin"))]
        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProduct update) {
            await product.UpdateProduct(update);
            return Ok();
        }

       

    }
}
