using Application.Services;
using Core.IAdminService;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceCollection
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IOrderService,OrderService>();   
            services.AddScoped<IRoleService,RolesService>();
        }
        }
}
