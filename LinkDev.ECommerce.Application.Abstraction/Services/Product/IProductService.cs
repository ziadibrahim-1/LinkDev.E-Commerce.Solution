using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;

namespace LinkDev.ECommerce.Application.Abstraction.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTo>> GetAllProductsAsync();
        Task<ProductDTo?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductBrandDTO>> GetAllProductBrandsAsync();
        Task<IEnumerable<ProductCategoryDTO>> GetAllProductCategoriesAsync();
    }
}
