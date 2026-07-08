using AutoMapper;
using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;
using LinkDev.ECommerce.Domain.Entity.Products;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Application.MappingProfile
{
    internal class ProductPictureUrlResolver : IValueResolver<Product, ProductDTo, string?>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string? Resolve(Product source, ProductDTo destination, string? destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["Urls:BaseApiUrl"]}/{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
