using ClientApi.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClientApi.Infrastructure.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<Guid> DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> condiction, string[] includes = null);
        IQueryable<T> GetAll();
    }
}
