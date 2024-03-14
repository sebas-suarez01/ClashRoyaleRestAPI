using ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.ExceptionHandlers;

internal class GetWarByIdExceptionHandler 
    : RequestExceptionHandler<GetModelByIdQuery<WarModel, WarId>, WarModel, string>
{
}
