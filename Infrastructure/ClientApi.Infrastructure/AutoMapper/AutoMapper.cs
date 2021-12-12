using AutoMapper;
using ClientApi.Core.Dtos.Cities;
using ClientApi.Core.Dtos.Clients;
using ClientApi.Core.Entities;

namespace ClientApi.Infrastructure.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            _ = CreateMap<City, CreateCityDto>().BeforeMap((entity, CreateCityDto) =>
            {
                entity.State = CreateCityDto.State.ToUpperInvariant();
            });
            _ = CreateMap<CreateCityDto, City>().BeforeMap((entity, CreateCityDto) =>
            {
                entity.State = CreateCityDto.State.ToUpperInvariant();
            });
            _ = CreateMap<UpdateCityDto, City>().BeforeMap((entity, CreateCityDto) =>
            {
                entity.State = CreateCityDto.State.ToUpperInvariant();
            });
            _ = CreateMap<City, UpdateCityDto>().BeforeMap((entity, CreateCityDto) =>
            {
                entity.State = CreateCityDto.State.ToUpperInvariant();
            });

            _ = CreateMap<City, CreateClientDto>().ReverseMap();
            _ = CreateMap<Client, UpdateClientDto>().ReverseMap();
        }
    }
}
