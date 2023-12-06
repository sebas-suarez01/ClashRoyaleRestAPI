using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.ExceptionHandlers;

internal class GetWarByIdExceptionHandler 
    : RequestExceptionHandler<GetModelByIdQuery<WarModel, int>, WarModel, int>
{
}
