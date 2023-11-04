using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.ExceptionHandlers
{
    internal class GetWarByIdExceptionHandler 
        : RequestExceptionHandler<GetModelByIdQuery<WarModel, int>, WarModel, int>
    {
    }
}
