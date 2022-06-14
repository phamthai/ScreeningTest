using AutoMapper;
using ScreeningTest.Entities;

namespace ScreeningTest.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
