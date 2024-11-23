using AutoMapper;
using TP.Application.Dtos.ProductDtos;
using TP.Domain;

namespace TP.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region Product Mapper
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<EditProductDto, Product>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            #endregion
        }
    }
}
