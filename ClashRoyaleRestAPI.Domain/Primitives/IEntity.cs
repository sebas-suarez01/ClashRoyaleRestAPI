namespace ClashRoyaleRestAPI.Domain.Primitives;

public interface IEntity<TId>
{
    public TId Id { get; }
}
