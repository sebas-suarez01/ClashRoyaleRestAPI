using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Domain.Errors;

public static partial class ErrorTypes
{
    public static class Models
    {
        public static Error DuplicateId(string description) => new(
                code: ErrorCode.DuplicateId,
                description: description);

        public static Error DuplicateId(params int[] ids) => new(
                code: ErrorCode.DuplicateId,
                description: "Id" + String.Join(",", ids) + "already exists");

        public static Error ModelNotFound(string model) => new(
                code: ErrorCode.ModelNotFound,
                description: $"{model} not found");

        public static Error IdNotFound(string description) => new(
                code: ErrorCode.IdNotFound,
                description: description);

        public static Error IdsNotMatch() => new(
                code: ErrorCode.IdsNotMatch,
                description: "Ids does not match");

        public static Error ChallengeClosed() => new(
                code: ErrorCode.ChallengeClosed,
                description: "Challenge is not open");

        public static Error PlayerNotHaveCard() => new(
                code: ErrorCode.PlayerNotHaveCard,
                description: "Player does not have card");
        public static Error DuplicateIndex(string description) => new(
                code: ErrorCode.DuplicateIndex,
                description: description);

        public static Error ValidationError(Error[] errors) => new(
            code: "ValidationError",
            description: "A validation problem occurred: " + string.Join(", ", errors.AsEnumerable()));


    }
}
