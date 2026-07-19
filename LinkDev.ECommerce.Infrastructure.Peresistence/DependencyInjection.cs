using LinkDev.ECommerce.Domain.Contracts.Peresistence;
using LinkDev.ECommerce.Infrastructure.Peresistence.Data;
using LinkDev.ECommerce.Infrastructure.Persistence.Data;
using LinkDev.ECommerce.Infrastructure.Persistence.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.ECommerce.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
            {
                options
                .UseLazyLoadingProxies()   
                .UseSqlServer(configuration.GetConnectionString("StoreContext"));
            });

            services.AddScoped(typeof(IStoreContextInitializer) ,typeof(StoreContextInitializer));
            services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
            
            return services;
        }
    }
}
