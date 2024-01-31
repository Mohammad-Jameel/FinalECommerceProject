using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Queries
{
    public static class CategoryQuery
    {
        public const string AddNewCategory = "dbo.AddCtegories";
        public const string DeleteCategory = "dbo.DeleteCategory";
        public const string UpdateCategory = "dbo.UpdateCategories";
        public const string GetAllCategories = "dbo.GetAllCategories";
    }
}
