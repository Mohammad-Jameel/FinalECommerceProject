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
    public class ProductService : IProductService
    {
        private readonly IProductRepository product1;

        public ProductService(IProductRepository product1)
        {
            this.product1 = product1;
        }

        public async Task<int> AddNewProduct(AddNewProduct addNewProduct)
        {
         var result=   await product1.AddNewProduct(addNewProduct);
            return result; 
        }

        public async Task DeleteProduct(int Id)
        {
            await product1.DeleteProduct(Id);
        }

        public async Task<List<GetAllProducts>> GetAllProducts()
        {
            var result= await product1.GetAllProducts();
            return result;
        }

        public async Task<List<GetCustomerProducts>> GetCustomerProducts()
        {
            var res= await product1.GetCustomerProducts();
            return res;
        }

        public async Task<List<GetProduuctDetails>> GetProduuctDetails(int id)
        {var result=await product1.GetProduuctDetails(id);
            return result;
            
        }

        public async Task UpdateProduct(UpdateProduct product)
        {
            await product1.UpdateProduct(product);
        }
    }
}
