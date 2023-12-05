using ClashRoyaleRestAPI.Application.Specifications;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IBaseRepository<TModel, UId>
    where TModel : class
{
    public Task<TModel> GetSingleByIdAsync(UId id);
    public Task<TModel> GetSingleByIdAsync(UId id, Specification<TModel> specification);
    public Task<PageList<TModel>> GetAllAsync(string? sortOrder, int page, int pageSize);
    public Task<IEnumerable<TModel>> GetModelDataAsync(Specification<TModel> specification);
    public Task<UId> Add(TModel model);
    public Task Update(TModel model);
    public Task Delete(TModel model);
    public Task Save();

}
