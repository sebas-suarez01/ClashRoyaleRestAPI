using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories;

public interface IBaseRepository<TModel, UId>
{
    public Task<TModel> GetSingleByIdAsync(UId id);
    public Task<PageList<TModel>> GetAllAsync(int page, int pageSize);
    public Task<UId> Add(TModel model);
    public Task Update(TModel model);
    public Task Delete(TModel model);
    public Task Save();

}
