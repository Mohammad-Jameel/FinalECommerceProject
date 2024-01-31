using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
   public interface ICategoryRepository
    {
        Task<List<GetAllCategories>> GetAllCategories();
        Task<int> AddNewCategory(Categories category);
        Task UpdateCategory(Categories categories);
        Task DeleteCategory(int Id);
    }
}
