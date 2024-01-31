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

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService category;

        public CategoryController(ICategoryService category)
        {
            this.category = category;
        }
        [AllowAnonymous]
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetCategories() { 
        var result= await category.GetAllCategories();
            return Ok(result);
        
        }
        [Authorize(Roles =("Admin ,MainAdmin"))]
        [HttpPost("AddCategory")]
        public async Task<IActionResult>AddCategory(Categories categories)
        {
            await category.AddNewCategory(categories);
            return Ok();
        }
        [Authorize(Roles = ("Admin ,MainAdmin"))]
        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult>UpdateCategory(Categories categories)
        {
            await category.UpdateCategory(categories);
            return Ok();
        }
        [Authorize(Roles = ("Admin ,MainAdmin"))]
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await category.DeleteCategory(id);
            return Ok();
        }

    }
}
