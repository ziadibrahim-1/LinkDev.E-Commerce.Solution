using AutoMapper;
using LinkDev.ECommerce.Application.Abstraction.DTOs.Product;
using LinkDev.ECommerce.Domain.Entity.Products;

namespace LinkDev.ECommerce.Application.MappingProfile
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductBrand, ProductBrandDTO>();
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<Product, ProductDTo>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand != null ? src.ProductBrand.Name : null))
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategory != null ? src.ProductCategory.Name : null))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductPictureUrlResolver>());
        }
    }
}
