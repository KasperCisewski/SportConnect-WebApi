using AutoMapper;
using SportConnect.Core.Domain;
using SportConnect.Infrastructure.Dto;

namespace SportConnect.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(config =>
                {
                    //here will be added mappings between domain classes and their DTOs
                    //for example: cfg.CreateMap<User, UserDto>();
                    config.CreateMap<User, UserDto>();
                })
                .CreateMapper();
    }
}
