namespace ClashRoyaleRestAPI.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T, U>
    {
        public Task<T?> GetSingleByIdAsync(U id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<U> Add(T model);
        public Task Update(T model);
        public Task Delete(T model);
        public Task<bool> ExistsId(U id);
        public Task Save();

    }
}
