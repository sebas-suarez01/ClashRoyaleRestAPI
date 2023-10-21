using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Common
{
    public class BaseRepository<T, U> : IBaseRepository<T, U> where T : class, IEntity<U>
    {
        protected readonly ClashRoyaleDbContext _context;
        public BaseRepository(ClashRoyaleDbContext context)
        {
            _context = context;
        }
        public virtual async Task<T?> GetSingleByIdAsync(U id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            return entity;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<U> Add(T model)
        {
            _context.Set<T>().Add(model);

            await Save();
            return model.Id;
        }
        public virtual async Task Delete(T model)
        {
            _context.Set<T>().Remove(model);
            await Save();
        }
        public virtual async Task Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await Save();
        }
        public virtual async Task Save() => await _context.SaveChangesAsync();
        public virtual async Task<bool> ExistsId(U id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id!.Equals(id));
        }
    }
}
