using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.War.Queries
{
    internal class GetAllWarQueryHandler : GetAllModelQueryHandler<WarModel, int>
    {
        public GetAllWarQueryHandler(IWarRepository repository) : base(repository)
        {
        }
    }
}
