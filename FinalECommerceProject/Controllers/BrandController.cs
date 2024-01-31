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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brand;

        public BrandController(IBrandService brand)
        {
            this.brand = brand;
        }
        [AllowAnonymous]
        [HttpGet("GetAllBrands")]
        public async Task<IActionResult> GetAllBrands() {
        var result=await brand.GetAllBrandsAsync();
            return Ok(result);
        
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpDelete("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(int id) {
            await brand.DeleteBrand(id);
            return Ok();
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpPut("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(Brands brands) { 
            await brand.UpdateBrand(brands);
            return Ok();
        }
        [Authorize(Roles = "Admin ,MainAdmin")]
        [HttpPost("AddNewBrand")]
        public async Task<IActionResult> AddBrand(Brands brands) { 
            var r=await brand.AddNewBrand(brands);
            return Ok(r);
        
        
        }





    }
}
