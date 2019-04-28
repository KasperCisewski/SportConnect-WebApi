using SportConnect.Core.Domain.Base;

namespace SportConnect.Core.Domain
{
    public class SportType : Entity<int>
    {
        public string SportName { get; set; }
        public int ProposedNumberOfParticipants { get; set; }
    }
}
