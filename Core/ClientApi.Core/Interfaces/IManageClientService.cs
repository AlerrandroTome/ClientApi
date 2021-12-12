using ClientApi.Core.Dtos.Clients;
using ClientApi.Core.Entities;

namespace ClientApi.Core.Interfaces
{
    public interface IManageClientService : IBaseService<Client, CreateClientDto, UpdateClientDto>
    {
    }
}
