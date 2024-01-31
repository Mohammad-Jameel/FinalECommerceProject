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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> AddNewCategory(Categories category)
        {
            var result = await _categoryRepository.AddNewCategory(category);
            return result;
        }

        public async Task DeleteCategory(int Id)
        {
            await _categoryRepository.DeleteCategory(Id);
        }

        public Task<List<GetAllCategories>> GetAllCategories()
        {
            var result=_categoryRepository.GetAllCategories();
            return result;
        }

        public async Task UpdateCategory(Categories categories)
        {
            await _categoryRepository.UpdateCategory(categories);
        }
    }
}
