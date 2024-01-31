using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
  public interface IBrandRepository
    {
        Task<List<Brands>> GetAllBrandsAsync();
        Task UpdateBrand(Brands brands);
        Task<int> AddNewBrand(Brands brands);
        Task DeleteBrand( int id);
    }
}
