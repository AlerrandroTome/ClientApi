using ClientApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClientApi.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            if (_context != null)
            {
                entity.InclusionDate = DateTime.Now;

                _context.Add(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<Guid> DeleteAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            if (_context != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity.Id;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> condiction, string[] includes = null)
        {
            var query = GetAll().Where(condiction);

            if (includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            if (_context != null)
            {
                entity.LastChangeDate = DateTime.Now;
                _context.Update(entity);

                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
