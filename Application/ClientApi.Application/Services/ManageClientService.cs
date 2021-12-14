using AutoMapper;
using ClientApi.Core.Dtos;
using ClientApi.Core.Dtos.Clients;
using ClientApi.Core.Entities;
using ClientApi.Core.Interfaces;
using ClientApi.Infrastructure.Context;
using ClientApi.Infrastructure.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Application.Services
{
    public class ManageClientService : IManageClientService
    {
        private readonly IMapper mapper;
        private readonly ClientContext context;
        private readonly IUnitOfWork unitOfWork;

        public ManageClientService(IMapper mapper, ClientContext context, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<Client>> CreateAsync(CreateClientDto dto)
        {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var client = mapper.Map<Client>(dto);
            var response = new Response<Client>();
            response.Data = await unitOfWork.Repository<Client>(context).CreateAsync(client);
            return response;
        }

        public async Task<Response<Guid>> DeleteAsync(Guid id)
        {
            var client = await unitOfWork.Repository<Client>(context).GetAsync(client => client.Id == id);
            _ = client ?? throw new ApplicationException("Client not found.");
            var response = new Response<Guid>();
            response.Data = await unitOfWork.Repository<Client>(context).DeleteAsync(client);
            return response;
        }

        public IQueryable<Client> Get()
        {
            return unitOfWork.Repository<Client>(context).GetAll();
        }

        public async Task<Response<Client>> UpdateAsync(UpdateClientDto dto)
        {
            _ = dto ?? throw new ArgumentNullException(nameof(dto));

            var clientEntity = await unitOfWork.Repository<Client>(context).GetAsync(client => client.Id == dto.Id);
            _ = clientEntity ?? throw new ApplicationException("Client not found.");

            var client = mapper.Map(dto, clientEntity);
            var response = new Response<Client>();
            response.Data = await unitOfWork.Repository<Client>(context).UpdateAsync(client);
            return response;
        }
    }
}
