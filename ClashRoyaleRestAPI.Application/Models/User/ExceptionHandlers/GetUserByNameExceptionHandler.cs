using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.User.Queries.GetUserByName;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers
{
    internal class GetUserByNameExceptionHandler
        : RequestExceptionHandler<GetUserByNameQuery, UserModel, string>
    {
    }
}
