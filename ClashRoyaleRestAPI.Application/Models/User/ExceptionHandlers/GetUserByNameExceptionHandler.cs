using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Auth.User;
using ClashRoyaleRestAPI.Application.Models.User.Queries.GetUserByName;

namespace ClashRoyaleRestAPI.Application.Models.User.ExceptionHandlers
{
    internal class GetUserByNameExceptionHandler
        : RequestExceptionHandler<GetUserByNameQuery, UserModel, string>
    {
    }
}
