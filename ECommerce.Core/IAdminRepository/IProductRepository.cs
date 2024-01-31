using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IProductRepository
    {
        Task<List<GetAllProducts>> GetAllProducts();
        Task<int> AddNewProduct(AddNewProduct addNewProduct);
        Task DeleteProduct(int Id);
        Task UpdateProduct(UpdateProduct product);
        Task <List<GetProduuctDetails>> GetProduuctDetails(int id);
        Task<List<GetCustomerProducts>> GetCustomerProducts();
    }
}
