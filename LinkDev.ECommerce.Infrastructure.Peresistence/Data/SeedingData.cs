using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Infrastructure.Peresistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Infrastructure.Persistence.Data
{
    public static class SeedingData
    {
        public static async Task SeedDataAsync(StoreContext dbContext)
        {
            if(!dbContext.Brands.Any())
            {
                var BrandsData = await File.ReadAllTextAsync("../LinkDev.ECommerce.Infrastructure.Peresistence/Data/Seeds/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                if(Brands?.Count > 0)
                {
                    await dbContext.Brands.AddRangeAsync(Brands);
                    await dbContext.SaveChangesAsync();
                }
            }
            if(!dbContext.Categories.Any())
            {
                var CategoriesData = await File.ReadAllTextAsync("../LinkDev.ECommerce.Infrastructure.Peresistence/Data/Seeds/categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData);
                if (Categories?.Count > 0)
                {
                    await dbContext.Categories.AddRangeAsync(Categories);
                    await dbContext.SaveChangesAsync();
                }
            }
            if(!dbContext.Products.Any())
            {
                var ProductsData = await File.ReadAllTextAsync("../LinkDev.ECommerce.Infrastructure.Peresistence/Data/Seeds/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products?.Count > 0)
                {
                    await dbContext.Products.AddRangeAsync(Products);
                    await dbContext.SaveChangesAsync();
                }
            }
        }


    }
}
