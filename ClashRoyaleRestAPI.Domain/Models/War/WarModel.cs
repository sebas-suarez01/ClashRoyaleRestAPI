using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Domain.Models.War
{
    public class WarModel : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
    }
}
