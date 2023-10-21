using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Domain.Errors
{
    public static partial class ErrorTypes
    {
        public static class Models
        {
            public static readonly Error DuplicateId = new(
                code: "Model.DuplicateId",
                description: "Id already exists");

            public static readonly Error ModelNotFound = new(
                code: "Model.NotFound",
                description: "Model not found");

            public static readonly Error IdNotFound = new(
                code: "Model.IdNotFound",
                description: "Id not found");

            public static readonly Error IdsNotMatch = new(
                code: "Model.IdsNotMatch",
                description: "Ids does not match");
        }
    }
}
