using LinkDev.ECommerce.APIs.Controllers.Controllers.Base;
using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;
using LinkDev.ECommerce.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.ECommerce.APIs.Controllers.Controllers.Products
{
    public class ProductController(IServiceManager serviceManager) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTo>>> GetProducts()
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTo>> GetProductById(int id)
        {
            var product = await serviceManager.ProductService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { StatusCode = 404, Message = $"Product with id {id} not found." });
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
