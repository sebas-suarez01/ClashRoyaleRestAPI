using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.User;

namespace ClashRoyaleRestAPI.Application.Models.User.Queries.GetUserByName
{
    public record GetUserByNameQuery(string Name) : IQuery<UserModel>;
}
