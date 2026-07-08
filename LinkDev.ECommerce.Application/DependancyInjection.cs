using LinkDev.ECommerce.Application.Abstraction.Services;
using LinkDev.ECommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.ECommerce.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddAutoMapper(M => { }, typeof(AssemplyInformation).Assembly);
            services.AddScoped(typeof(IServiceManager) , typeof(ServiceManager));
            return services;
        }
    }
}
