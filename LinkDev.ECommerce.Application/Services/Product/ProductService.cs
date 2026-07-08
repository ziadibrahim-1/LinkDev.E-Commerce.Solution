using AutoMapper;
using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;
using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Application.Abstraction.Services.Product;
using LinkDev.ECommerce.Domain.Contracts;

namespace LinkDev.ECommerce.Application.Services.Product
{
    public class ProductService(IUnitOfWork unitOfWork , IMapper mapper) : IProductService
    {
        
        public async Task<IEnumerable<ProductBrandDTO>> GetAllProductBrandsAsync()
        {
            var productBrands = await unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();
            var ProductBrandResult = mapper.Map<IEnumerable<ProductBrandDTO>>(productBrands);
            return ProductBrandResult;

        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetAllProductCategoriesAsync()
        {
            var productCategories = await unitOfWork.GetRepository<ProductCategory,int>().GetAllAsync();
            var ProductCategoryResult = mapper.Map<IEnumerable<ProductCategoryDTO>>(productCategories);
            return ProductCategoryResult;
        }

        public async Task<IEnumerable<ProductDTo>> GetAllProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Domain.Entity.Products.Product, int>().GetAllAsync();
            var ProductResult = mapper.Map<IEnumerable<ProductDTo>>(products);
            return ProductResult;
        }

        public async Task<ProductDTo?> GetProductByIdAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Domain.Entity.Products.Product, int>().GetAsync(id);
            var ProductResult = mapper.Map<ProductDTo>(product);
            return ProductResult;
        }
    }
}
