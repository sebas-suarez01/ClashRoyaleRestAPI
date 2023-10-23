using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;

namespace ClashRoyaleRestAPI.Application.Auth.User.Queries.GetUserByName
{
    public record GetUserByNameQuery(string Name) : IQuery<UserResponse>;
}
