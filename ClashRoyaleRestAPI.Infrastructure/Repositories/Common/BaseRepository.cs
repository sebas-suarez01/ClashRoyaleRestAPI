using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using ClashRoyaleRestAPI.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Common
{
    public class BaseRepository<TModel, UId> : IBaseRepository<TModel, UId>
        where TModel : class, IEntity<UId>
    {
        protected readonly ClashRoyaleDbContext _context;
        public BaseRepository(ClashRoyaleDbContext context)
        {
            _context = context;
        }

        #region Interface Methods

        #region Queries
        public virtual async Task<TModel> GetSingleByIdAsync(UId id)
        {
            var entity = await _context.Set<TModel>().FindAsync(id) ?? throw new IdNotFoundException<UId>(id);

            return entity;
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        #endregion

        #region Commands

        public virtual async Task<UId> Add(TModel model)
        {
            _context.Set<TModel>().Add(model);

            await Save();
            return model.Id;
        }
        public virtual async Task Delete(TModel model)
        {
            _context.Set<TModel>().Remove(model);
            await Save();
        }
        public virtual async Task Update(TModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await Save();
        }

        #endregion

        #endregion

        #region Extra Methods

        public virtual async Task Save() => await _context.SaveChangesAsync();
        protected virtual async Task<bool> ExistsId(UId id)
        {
            return await _context.Set<TModel>().AnyAsync(e => e.Id!.Equals(id));
        }

        protected IQueryable<T> ApplySpecification<T>(Specification<T> specification)
            where T : class
        {
            return SpecificationEvaluator.GetQuery(_context.Set<T>(), specification);
        }

        #endregion


    }
}
