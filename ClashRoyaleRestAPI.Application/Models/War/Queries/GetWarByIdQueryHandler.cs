using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.Queries
{
    public class GetWarByIdQueryHandler : GetModelByIdQueryHandler<WarModel, int>
    {
        public GetWarByIdQueryHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
