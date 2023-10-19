using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Domain.Errors
{
    public static partial class ErrorTypes
    {
        public static class Instances
        {
            public static readonly Error None = new(string.Empty, string.Empty);

            public static readonly Error NullValue = new("Error.NullValue", "The specific result value is null");
        }
    }
}
