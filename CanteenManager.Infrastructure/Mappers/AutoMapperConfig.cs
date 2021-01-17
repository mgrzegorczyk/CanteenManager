using AutoMapper;
using CanteenManager.Core.Models;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>();
                cfg.CreateMap<Order, OrderDto>();
            });

            return config.CreateMapper();
        }
    }
}