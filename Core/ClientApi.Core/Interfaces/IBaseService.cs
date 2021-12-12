using ClientApi.Core.Dtos;
using ClientApi.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Core.Interfaces
{
    public interface IBaseService<Entity, CreateDTO, UpdateDTO>
        where CreateDTO : class where UpdateDTO : class where Entity : EntityBase
    {
        Task<Response<Entity>> CreateAsync(CreateDTO dto);
        Task<Response<Entity>> UpdateAsync(UpdateDTO dto);
        Task<Response<Guid>> DeleteAsync(Guid id);
        IQueryable<Entity> Get();
    }
}
