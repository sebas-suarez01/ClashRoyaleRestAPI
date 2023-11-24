namespace ClashRoyaleRestAPI.Domain.Shared;

public class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors) : base(false, errors)
    {
        Errors = errors;
    }

    public new Error[] Errors { get; }

    public static ValidationResult Create(Error[] errors)
    {
        return new ValidationResult(errors);
    }
}

public class ValidationResult<TResult> : Result<TResult>, IValidationResult
{
    private ValidationResult(Error[] errors) : base(default, false, errors)
    {
        Errors = errors;
    }

    public new Error[] Errors { get; }

    public static ValidationResult<TResult> Create(Error[] errors)
    {
        return new ValidationResult<TResult>(errors);
    }
}
