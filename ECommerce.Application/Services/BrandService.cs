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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<int> AddNewBrand(Brands brands)
        {
          var r= await _brandRepository.AddNewBrand(brands);
            return r;
        }

        public async Task DeleteBrand(int id)
        {
            await _brandRepository.DeleteBrand(id);
        }

        public async Task<List<Brands>> GetAllBrandsAsync()
        {
            var r=await _brandRepository.GetAllBrandsAsync();
            return r;
        }

        public async Task UpdateBrand(Brands brands)
        {
            await _brandRepository.UpdateBrand(brands);
        }
    }
}
