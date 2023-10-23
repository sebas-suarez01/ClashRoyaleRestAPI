using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;

namespace ClashRoyaleRestAPI.Application.Auth.User.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IQuery<UserResponse>;
}
