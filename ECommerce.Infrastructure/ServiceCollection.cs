using Core.Interface;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollection
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolesRepository,RolesRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IBrandRepository,BrandRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<ISalesRepository,SalesRepository>();
            services.AddScoped<IProductRepository, ProductRepositpry>();

        }
        }
}
