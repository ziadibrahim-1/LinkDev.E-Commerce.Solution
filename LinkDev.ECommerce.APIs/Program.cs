using LinkDev.ECommerce.Infrastructure.Peresistence.Data;
using LinkDev.ECommerce.Infrastructure.Persistence;
using LinkDev.ECommerce.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace LinkDev.ECommerce.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Configure Services
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistence(builder.Configuration);

            #endregion

            var app = builder.Build();

            #region Update Database
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreContext>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
                if(pendingMigrations.Any())
                     await context.Database.MigrateAsync();

                await SeedingData.SeedDataAsync(context);
                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
            #endregion

            #region Configure
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.MapOpenApi();
                app.UseSwaggerUI();
                app.UseSwagger();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
