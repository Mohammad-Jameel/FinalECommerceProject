using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Queries
{
    public static class ProductQuery
    { public const string AddNewProduct = "AddNewProduct";
        public const string DeleteProduct = "DeleteProduct";
        public const string GetAllProducts = "GetAllProduct";
        public const string UpdateProduct = "UpdateProduct";
        public const string GetProductDetails = "dbo.GetTheProductDetails";
        public const string GetProductForCustomers = "dbo.GetTheProductsForTheCustomers";
    }
}
