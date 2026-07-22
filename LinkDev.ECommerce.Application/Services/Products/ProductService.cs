using AutoMapper;
using LinkDev.ECommerce.Application.Abstraction.Common;
using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;
using LinkDev.ECommerce.Application.Abstraction.Services.Product;
using LinkDev.ECommerce.Application.Exceptions;
using LinkDev.ECommerce.Domain.Contracts.Peresistence;
using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Domain.Specefication.Products;

namespace LinkDev.ECommerce.Application.Services.Products
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

        public async Task<Pagination<ProductDTo>> GetAllProductsAsync(ProductSpeceficationsParams param)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(
                param.Sort,
                param.BrandId,
                param.CategoryId,
                param.PageIndex,
                param.PageSize,
                param.Search
            );
            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpcesAsync(specs);
            var CountSpecs = new ProductForCountSpecefications(param.BrandId , param.CategoryId ,param.Search);
            var Count = await unitOfWork.GetRepository<Product, int>().CountAsync(CountSpecs);
            var data = mapper.Map<IEnumerable<ProductDTo>>(products);
            return new(param.PageIndex, param.PageSize , Count) { Data = data};
        }

        public async Task<ProductDTo?> GetProductByIdAsync(int id)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetWithSpcesAsync(specs);
            if (product is null)
                throw new NotFoundException(nameof(Product), id);
            var ProductResult = mapper.Map<ProductDTo>(product);
            return ProductResult;
        }
    }
}
