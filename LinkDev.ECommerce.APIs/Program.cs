using LinkDev.ECommerce.APIs.Extentions;
using LinkDev.ECommerce.Application;
using LinkDev.ECommerce.Infrastructure.Persistence;
using AssemblyInformation = LinkDev.ECommerce.APIs.Controllers.AssemblyInformation;
namespace LinkDev.ECommerce.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Configure Services
            builder.Services
                .AddControllers()
                .AddApplicationPart(typeof(AssemblyInformation).Assembly);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplicationServices();

            #endregion

            var app = builder.Build();

            #region Databases Initialization
            await app.InitializeStoreContext();
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

            app.UseStaticFiles();
            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
