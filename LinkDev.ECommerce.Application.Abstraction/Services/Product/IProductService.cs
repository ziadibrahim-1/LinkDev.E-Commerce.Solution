using LinkDev.ECommerce.Application.Abstraction.Common;
using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;

namespace LinkDev.ECommerce.Application.Abstraction.Services.Product
{
    public interface IProductService
    {
        Task<Pagination<ProductDTo>> GetAllProductsAsync(ProductSpeceficationsParams param);
        Task<ProductDTo?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductBrandDTO>> GetAllProductBrandsAsync();
        Task<IEnumerable<ProductCategoryDTO>> GetAllProductCategoriesAsync();
    }
}
