using AutoMapper;
using ClientApi.Core.Dtos;
using ClientApi.Core.Dtos.Cities;
using ClientApi.Core.Entities;
using ClientApi.Core.Interfaces;
using ClientApi.Infrastructure.Context;
using ClientApi.Infrastructure.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Application.Services
{
    public class ManageCityService : IManageCityService
    {
        private readonly IMapper mapper;
        private readonly ClientContext context;
        private readonly IUnitOfWork unitOfWork;

        public ManageCityService(IMapper mapper, ClientContext context, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<City>> CreateAsync(CreateCityDto dto)
        {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var city = mapper.Map<City>(dto);
            var response = new Response<City>();
            response.Data = await unitOfWork.Repository<City>(context).CreateAsync(city);
            return response;
        }

        public async Task<Response<Guid>> DeleteAsync(Guid id)
        {
            var city = await unitOfWork.Repository<City>(context).GetAsync(city => city.Id == id, new[] { "Clients" });
            _ = city ?? throw new ApplicationException("City not found.");

            if (city.Clients.Any())
            {
                throw new ApplicationException($"The {city.Name} has registered clients. Please update the profile " +
                    $"of these client before trying to remove this city again.");
            }

            var response = new Response<Guid>();
            response.Data = await unitOfWork.Repository<City>(context).DeleteAsync(city);
            return response;
        }

        public IQueryable<City> Get()
        {
            return unitOfWork.Repository<City>(context).GetAll();
        }

        public async Task<Response<City>> UpdateAsync(UpdateCityDto dto)
        {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var cityEntity = await unitOfWork.Repository<City>(context).GetAsync(city => city.Id == dto.Id);
            _ = cityEntity ?? throw new ApplicationException("City not found.");

            var city = mapper.Map(dto, cityEntity);
            var response = new Response<City>();
            response.Data = await unitOfWork.Repository<City>(context).UpdateAsync(city);
            return response;
        }
    }
}
