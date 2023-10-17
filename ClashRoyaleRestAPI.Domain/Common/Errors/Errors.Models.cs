using ErrorOr;

namespace ClashRoyaleRestAPI.Domain.Common.Errors
{
    public static  partial class Errors
    {
        public static class Models
        {
            public static Error DuplicateId => Error.Conflict(
                code: "Model.DuplicateId",
                description: "Id already exists");

            public static Error ModelNotFound => Error.NotFound(
                code: "Model.NotFound",
                description: "Model not found");

            public static Error IdNotFound => Error.NotFound(
                code: "Model.IdNotFound",
                description: "Id not found");
        }
    }
}
