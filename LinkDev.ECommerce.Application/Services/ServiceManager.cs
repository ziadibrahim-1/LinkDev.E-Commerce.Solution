using AutoMapper;
using LinkDev.ECommerce.Application.Abstraction.Services;
using LinkDev.ECommerce.Application.Abstraction.Services.Product;
using LinkDev.ECommerce.Application.Services.Products;
using LinkDev.ECommerce.Domain.Contracts.Peresistence;

namespace LinkDev.ECommerce.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork , _mapper));
        }
        public IProductService ProductService => _productService.Value;
    }
}
