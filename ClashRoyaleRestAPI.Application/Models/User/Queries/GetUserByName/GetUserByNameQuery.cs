using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.User.Queries.GetUserByName
{
    public record GetUserByNameQuery(string Name) : IQuery<UserModel>;
}
