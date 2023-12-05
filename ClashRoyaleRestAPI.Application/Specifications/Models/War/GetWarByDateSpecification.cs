using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Specifications.Models.War
{
    public class GetWarByDateSpecification : Specification<WarModel>
    {
        public GetWarByDateSpecification(DateTime date) : base(w => w.StartDate > date)
        {
        }
    }
}
