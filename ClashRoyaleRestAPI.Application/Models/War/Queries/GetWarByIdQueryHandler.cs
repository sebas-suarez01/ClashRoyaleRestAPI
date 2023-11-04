using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.Queries
{
    internal class GetWarByIdQueryHandler : GetModelByIdQueryHandler<WarModel, int>
    {
        public GetWarByIdQueryHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
