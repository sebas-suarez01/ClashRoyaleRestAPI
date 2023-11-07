using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Infrastructure.Specifications.Models.War
{
    internal class GetWarByDateSpecification : Specification<WarModel>
    {
        public GetWarByDateSpecification(DateTime date) : base(w => w.StartDate > date)
        {
        }
    }
}
