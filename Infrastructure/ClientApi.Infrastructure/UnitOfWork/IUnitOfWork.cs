using ClientApi.Core.Entities;
using ClientApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>(DbContext context) where T : EntityBase;
    }
}
