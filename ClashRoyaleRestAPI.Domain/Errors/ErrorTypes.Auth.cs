using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Domain.Errors
{
    public static partial class ErrorTypes
    {
        public static class Auth
        {
            public static readonly Error UsernameNotFound = new("Error.UsernameNotFound", "Username does not exist");
            public static readonly Error DuplicateUsername = new("Error.DuplicateUsername", "Username already exists");
            public static readonly Error InvalidCredentials = new("Error.InvalidCredentials", "InvalidCredentials");
            public static readonly Error InvalidPassword = new("Error.InvalidPassword", "Invalid password");
        }
    }
}
