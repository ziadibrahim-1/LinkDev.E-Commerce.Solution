using LinkDev.ECommerce.APIs.Controllers.Error;
using LinkDev.ECommerce.APIs.Extentions;
using LinkDev.ECommerce.APIs.Midlewares;
using LinkDev.ECommerce.Application;
using LinkDev.ECommerce.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
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
                .AddApplicationPart(typeof(AssemblyInformation).Assembly)
                .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressModelStateInvalidFilter = false;
                        options.InvalidModelStateResponseFactory = (actionContext) =>
                        {
                            var errors = actionContext.ModelState.Where(e => e.Value!.Errors.Count > 0)
                            .Select(e => new ApiValidationErrorResponse.ValidationError
                            {
                                Field = e.Key,
                                Message = e.Value!.Errors.Select(er => er.ErrorMessage)
                            });
                            return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = errors });
                        };
                    }
                );
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
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.MapOpenApi();
                app.UseSwaggerUI();
                app.UseSwagger();
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
