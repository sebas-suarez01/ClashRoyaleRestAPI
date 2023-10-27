using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleRestAPI.Infrastructure.Common;

class LazilyResolved<T> : Lazy<T>
    where T : notnull
{
    public LazilyResolved(IServiceProvider serviceProvider)
        : base(serviceProvider.GetRequiredService<T>)
    {
    }
}
