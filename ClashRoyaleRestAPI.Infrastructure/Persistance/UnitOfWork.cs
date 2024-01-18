using ClashRoyaleRestAPI.Application.Interfaces;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ClashRoyaleDbContext _context;
    public UnitOfWork(ClashRoyaleDbContext context)
    {
        _context = context;
    }
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
