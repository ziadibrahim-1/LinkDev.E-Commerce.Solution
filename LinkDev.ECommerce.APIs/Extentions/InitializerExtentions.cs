using LinkDev.ECommerce.Domain.Contracts;

namespace LinkDev.ECommerce.APIs.Extentions
{
    public static class InitializerExtentions
    {
        public static async Task<WebApplication> InitializeStoreContext(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var StoreContextInitializer = services.GetRequiredService<IStoreContextInitializer>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await StoreContextInitializer.InitializeAsync();
                await StoreContextInitializer.SeedAsync();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
            return app;
        }
    }
}
