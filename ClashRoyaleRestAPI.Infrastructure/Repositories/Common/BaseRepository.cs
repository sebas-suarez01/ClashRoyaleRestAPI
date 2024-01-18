using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Common.Interfaces;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Repositories.Common;

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
    public virtual async Task<TModel> GetSingleByIdAsync(UId id, Specification<TModel> specification)
    {
        var entity = await ApplySpecification(specification).FirstOrDefaultAsync()
            ?? throw new IdNotFoundException<UId>(id);

        return entity;
    }

    public virtual async Task<IEnumerable<TModel>> GetModelDataAsync(Specification<TModel> specification)
    {
        var entity = await ApplySpecification(specification)
            .ToListAsync();

        return entity;
    }

    public virtual async Task<PageList<TModel>> GetAllAsync(string? sortOrder, int page, int pageSize)
    {
        await Task.CompletedTask;

        var queryable = _context.Set<TModel>().AsQueryable();

        if (sortOrder?.ToLower() == "desc")
        {
            queryable = queryable.OrderByDescending(q => q.Id);
        }

        return PageList<TModel>.Create(queryable, page, pageSize);
    }

    #endregion

    #region Commands

    public virtual async Task<UId> Add(TModel model)
    {
        await Task.CompletedTask;

        _context.Set<TModel>().Add(model);

        return model.Id;
    }
    public virtual async Task Delete(TModel model)
    {
        await Task.CompletedTask;
        
        _context.Set<TModel>().Remove(model);
    }
    public virtual async Task Update(TModel model)
    {
        await Task.CompletedTask;

        _context.Entry(model).State = EntityState.Modified;
    }

    #endregion

    #endregion

    #region Extra Methods

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
