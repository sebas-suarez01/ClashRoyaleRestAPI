using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.War;

namespace ClashRoyaleRestAPI.Application.War.Queries
{
    public class GetWarByIdQueryHandler : GetModelByIdQueryHandler<WarModel, int>
    {
        public GetWarByIdQueryHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
