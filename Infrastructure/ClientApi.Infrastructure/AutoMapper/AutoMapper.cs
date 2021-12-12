using AutoMapper;
using ClientApi.Core.Dtos.Cities;
using ClientApi.Core.Dtos.Clients;
using ClientApi.Core.Entities;
using ClientApi.Core.Enums;
using System;

namespace ClientApi.Infrastructure.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // Cities
            _ = CreateMap<City, CreateCityDto>().BeforeMap((entity, dto) =>
            {
                dto.State = entity.State.ToUpperInvariant();
            });
            _ = CreateMap<CreateCityDto, City>().BeforeMap((dto, entity) =>
            {
                entity.State = dto.State.ToUpperInvariant();
            });
            _ = CreateMap<UpdateCityDto, City>().BeforeMap((dto, entity) =>
            {
                entity.State = dto.State.ToUpperInvariant();
            });
            _ = CreateMap<City, UpdateCityDto>().BeforeMap((entity, dto) =>
            {
                dto.State = entity.State.ToUpperInvariant();
            });

            // Clients
            _ = CreateMap<Client, CreateClientDto>().BeforeMap((entity, dto) =>
            {
                dto.Gender = (EGender)Enum.Parse(typeof(EGender), entity.Gender);
            });
            _ = CreateMap<CreateClientDto, Client>().BeforeMap((dto, entity) =>
            {
                entity.Gender = dto.Gender.ToString();
                var time = DateTime.Now.Date - dto.BirthDate.Date;
                entity.Age = new DateTime(time.Ticks).Year - 1;
            });
            _ = CreateMap<UpdateClientDto, Client>().BeforeMap((dto, entity) =>
            {
                entity.Gender = dto.Gender.ToString();
                var time = DateTime.Now.Date - dto.BirthDate.Date;
                entity.Age = new DateTime(time.Ticks).Year - 1;
            });
            _ = CreateMap<Client, UpdateClientDto>().BeforeMap((entity, dto) =>
            {
                dto.Gender = (EGender)Enum.Parse(typeof(EGender), entity.Gender);
            });
        }
    }
}
