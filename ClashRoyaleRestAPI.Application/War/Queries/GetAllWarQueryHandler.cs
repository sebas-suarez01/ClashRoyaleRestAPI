using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.War;

namespace ClashRoyaleRestAPI.Application.War.Queries
{
    public class GetAllWarQueryHandler : GetAllModelQueryHandler<WarModel, int>
    {
        public GetAllWarQueryHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
