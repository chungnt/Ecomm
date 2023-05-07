using AutoMapper;
using Ecomm.Data.Dto.Product;
using Ecomm.Data.Entities;

namespace Ecomm.Data.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
