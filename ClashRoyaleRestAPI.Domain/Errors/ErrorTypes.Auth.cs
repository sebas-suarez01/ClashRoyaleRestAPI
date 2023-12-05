using ClashRoyaleRestAPI.Domain.Shared;
using System.Net;

namespace ClashRoyaleRestAPI.Domain.Errors;

public static partial class ErrorTypes
{
    public static class Auth
    {
        public static Error UsernameNotFound() => new(
                HttpStatusCode.NotFound,
                ErrorCode.UsernameNotFound,
                "Username does not exist");
        public static Error DuplicateUsername() => new(
                HttpStatusCode.Conflict,
                ErrorCode.DuplicateUsername,
                "Username already exists");
        public static Error InvalidCredentials() => new(
                HttpStatusCode.BadRequest,
                ErrorCode.InvalidCredentials,
                "InvalidCredentials");
        public static Error InvalidPassword() => new(
                HttpStatusCode.BadRequest,
                ErrorCode.InvalidPassword,
                "Invalid password");
    }
}
