using System.Data;

namespace ClashRoyaleRestAPI.Application.Interfaces;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
    public IDbTransaction BeginTransaction();
}
