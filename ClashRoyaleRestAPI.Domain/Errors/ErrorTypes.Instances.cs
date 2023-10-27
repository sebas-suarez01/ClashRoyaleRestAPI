using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Domain.Errors
{
    public static partial class ErrorTypes
    {
        public static class Instances
        {
            public static Error None() => new(string.Empty, string.Empty);


            public static Error NullValue() => new(ErrorCode.NullValue, "The specific result value is null");

        }
    }
}
