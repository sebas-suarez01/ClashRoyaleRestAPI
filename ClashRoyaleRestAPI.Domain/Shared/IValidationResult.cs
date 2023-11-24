namespace ClashRoyaleRestAPI.Domain.Shared;

public interface IValidationResult
{
    Error[] Errors { get; }
}
