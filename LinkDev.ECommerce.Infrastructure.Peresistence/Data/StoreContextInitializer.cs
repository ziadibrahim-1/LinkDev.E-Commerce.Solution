using LinkDev.ECommerce.Domain.Contracts;
using LinkDev.ECommerce.Domain.Entity.Products;
using LinkDev.ECommerce.Infrastructure.Peresistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace LinkDev.ECommerce.Infrastructure.Persistence.Data
{
    internal class StoreContextInitializer(StoreContext _StoreContext) : IStoreContextInitializer
    {

        public async Task InitializeAsync()
        {
            var pendingMigrations = await _StoreContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
                await _StoreContext.Database.MigrateAsync();
        }

        public async Task SeedAsync()
        {
            if (!_StoreContext.Brands.Any())
            {
                var BrandsData = await File.ReadAllTextAsync("../LinkDev.ECommerce.Infrastructure.Peresistence/Data/Seeds/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                if (Brands?.Count > 0)
                {
                    await _StoreContext.Brands.AddRangeAsync(Brands);
                    await _StoreContext.SaveChangesAsync();
                }
            }
            if (!_StoreContext.Categories.Any())
            {
                var CategoriesData = await File.ReadAllTextAsync("../LinkDev.ECommerce.Infrastructure.Peresistence/Data/Seeds/categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData);
                if (Categories?.Count > 0)
                {
                    await _StoreContext.Categories.AddRangeAsync(Categories);
                    await _StoreContext.SaveChangesAsync();
                }
            }
            if (!_StoreContext.Products.Any())
            {
                var ProductsData = await File.ReadAllTextAsync("../LinkDev.ECommerce.Infrastructure.Peresistence/Data/Seeds/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products?.Count > 0)
                {
                    await _StoreContext.Products.AddRangeAsync(Products);
                    await _StoreContext.SaveChangesAsync();
                }
            }
        }
    }
}
