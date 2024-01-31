using Core.Entity;
using Core.Interface;
using Dapper;
using ECommerce.Infrastructure.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepositpry : IProductRepository
    {
        private readonly string connectionstring;
        private readonly IConfiguration _configuration;

        public ProductRepositpry( IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("DBConnection");
        }
        public async Task<int> AddNewProduct(AddNewProduct addNewProduct)
        {
            using(var connection=new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(ProductQuery.AddNewProduct,
                    new {description=addNewProduct.Description,productname=addNewProduct.ProductName,price=addNewProduct.Price,
                quantity=addNewProduct.Quantity,producttype=addNewProduct.ProductType,brand=addNewProduct.Brand,image1=addNewProduct.Image1,image2=addNewProduct.Image2,image3=addNewProduct.Image3,
                        image4 = addNewProduct.Image4  },commandType:System.Data.CommandType.StoredProcedure);
                return addNewProduct.Id;

            }
        }

        public async Task DeleteProduct(int Id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(ProductQuery.DeleteProduct, new {id=Id},commandType:System.Data.CommandType.StoredProcedure);
            }
            }

        public async Task<List<GetAllProducts>> GetAllProducts()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetAllProducts>(ProductQuery.GetAllProducts, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            }

        public async Task<List<GetCustomerProducts>> GetCustomerProducts()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetCustomerProducts>(ProductQuery.GetProductForCustomers, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<GetProduuctDetails>> GetProduuctDetails(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var result = await connection.QueryAsync<GetProduuctDetails>(ProductQuery.GetProductDetails, new {id=id }, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task UpdateProduct(UpdateProduct product)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                await connection.QueryAsync(ProductQuery.UpdateProduct, new
                {
                    description = product.Description,
                    productname = product.ProductName,
                    price =       product.Price,
                    quantity =    product.Quantity,
                    producttype = product.ProductType,
                    brand =       product.Brand,image1=product.Image1,image2=product.Image2,image3=product.Image3,image4= product.Image4
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
            }

     
    }
}
