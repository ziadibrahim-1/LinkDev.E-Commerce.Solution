using LinkDev.ECommerce.Application.Abstraction.Services.Product;

namespace LinkDev.ECommerce.Application.Abstraction.Services
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
    }
}
