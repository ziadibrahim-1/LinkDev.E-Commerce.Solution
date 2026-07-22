using LinkDev.ECommerce.APIs.Controllers.Controllers.Base;
using LinkDev.ECommerce.Application.Abstraction.Common;
using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;
using LinkDev.ECommerce.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.ECommerce.APIs.Controllers.Controllers.Products
{
    public class ProductController(IServiceManager serviceManager) : BaseApiController(serviceManager)
    {

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDTo>>> GetProducts([FromQuery]ProductSpeceficationsParams param)
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync(param);
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTo>> GetProductById(int id)
        {
            var product = await serviceManager.ProductService.GetProductByIdAsync(id);
            
            return Ok(product);
        }
        [HttpGet("category")]
        public async Task<ActionResult<ProductCategoryDTO>> GetCategories()
        {
            var categories = await serviceManager.ProductService.GetAllProductCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrandDTO>> GetBrands()
        {
            var brands = await serviceManager.ProductService.GetAllProductBrandsAsync();
            return Ok(brands);
        }
    }
}
