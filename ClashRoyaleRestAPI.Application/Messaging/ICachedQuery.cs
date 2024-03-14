using ClashRoyaleRestAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleRestAPI.Application.Messaging;

public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery
{}

public interface ICachedQuery
{
    string CacheKey { get; }
    TimeSpan? Expiration { get; }
}