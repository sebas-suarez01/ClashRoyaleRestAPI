using ClashRoyaleRestAPI.Domain.Shared;
using System.Net;

namespace ClashRoyaleRestAPI.Domain.Errors;

public static partial class ErrorTypes
{
    public static class Models
    {
        public static Error DuplicateId(string description) => new(
                httpStatusCode: HttpStatusCode.Conflict,
                code: ErrorCode.DuplicateId,
                description: description);

        public static Error DuplicateId(params int[] ids) => new(
                httpStatusCode: HttpStatusCode.Conflict,
                code: ErrorCode.DuplicateId,
                description: "Id" + String.Join(",", ids) + "already exists");

        public static Error ModelNotFound(string model) => new(
                httpStatusCode: HttpStatusCode.NotFound,
                code: ErrorCode.ModelNotFound,
                description: $"{model} not found");

        public static Error IdNotFound(string description) => new(
                httpStatusCode: HttpStatusCode.NotFound,
                code: ErrorCode.IdNotFound,
                description: description);

        public static Error IdsNotMatch(params int[] ids) => new(
                httpStatusCode: HttpStatusCode.BadRequest,
                code: ErrorCode.IdsNotMatch,
                description: "Ids " + string.Join(",", ids) + " do not match");

        public static Error ChallengeClosed() => new(
                httpStatusCode: HttpStatusCode.BadRequest,
                code: ErrorCode.ChallengeClosed,
                description: "Challenge is not open");

        public static Error PlayerNotHaveCard() => new(
                httpStatusCode: HttpStatusCode.BadRequest,
                code: ErrorCode.PlayerNotHaveCard,
                description: "Player does not have card");
        public static Error DuplicateIndex(string description) => new(
                httpStatusCode: HttpStatusCode.Conflict,
                code: ErrorCode.DuplicateIndex,
                description: description);

        public static Error ValidationError(Error[] errors) => new(
                httpStatusCode: HttpStatusCode.BadRequest,
                code: ErrorCode.Validation,
                description: "A validation problem occurred: " + string.Join(", ", errors.AsEnumerable()));


    }
}
