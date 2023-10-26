using ClashRoyaleRestAPI.Domain.Common.Interfaces;

namespace ClashRoyaleRestAPI.Domain.Models.War
{
    public class WarModel : IEntity<int>
    {
        private WarModel() { }
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }

        public static WarModel Create(DateTime start) 
        {
            return new WarModel()
            {
                StartDate = start,
            };
        }
    }
}
