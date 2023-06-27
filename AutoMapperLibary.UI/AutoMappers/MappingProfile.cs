using AutoMapper;
using AutoMapperLibary.UI.DTOS;
using AutoMapperLibary.UI.Models;

namespace AutoMapperLibary.UI.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, ProductDto>(); //İlişkili veri için map yapmalıyız..

            CreateMap<Product, ProductDto>().IncludeMembers(i => i.Category); // ilişkili veri için yükleme yapıyoruz..

            //For member: Entity ve dto arasında ki isimler farklı ise bunu belirtiyoruz..

            CreateMap<Product, ProductDto>().ForMember(dest => dest.NamePrice, opr => opr.MapFrom(src => src.ProductName + " " + src.Price)).ForMember(i => i.ExampleCategoryName, opr => opr.MapFrom(src => src.Category.CategoryName)).ForMember(i => i.ProductPrice, opt => opt.MapFrom(src => src.Prices())).ReverseMap();
        }
    }
}
