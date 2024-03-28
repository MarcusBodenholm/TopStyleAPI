using AutoMapper;
using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Domain.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDTO, Product>()
                .ForMember(dest => dest.Title,
                o => o.MapFrom(p => p.Title))
                .ForMember(dest => dest.Description,
                o => o.MapFrom(p => p.Description))
                .ForMember(dest => dest.Price,
                o => o.MapFrom(p => p.Price));
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductTitle,
                o => o.MapFrom(p => p.Title))
                .ForMember(dest => dest.ProductDescription,
                o => o.MapFrom(p => p.Description))
                .ForMember(dest => dest.ProductPrice,
                o => o.MapFrom(p => p.Price))
                .ForMember(dest => dest.ProductID,
                o => o.MapFrom(p => p.ProductID))
                .ForMember(dest => dest.CategoryID,
                o => o.MapFrom(p => p.Category.CategoryID))
                .ForMember(dest => dest.CategoryName,
                o => o.MapFrom(p => p.Category.CategoryName));
        }
    }
}
