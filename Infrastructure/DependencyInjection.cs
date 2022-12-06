using Microsoft.Extensions.DependencyInjection;
using Zay.ApplicationCore.Interfaces;
using Zay.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace Zay.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddSingleton<IMongoDbFactory>(new MongoDbFactory(configuration.GetSection("MongoDB:ConnectionString").Value));
            return services;
        }
    }
}
