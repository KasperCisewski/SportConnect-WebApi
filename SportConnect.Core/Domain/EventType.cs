using SportConnect.Core.Domain.Base;

namespace SportConnect.Core.Domain
{
    public class EventType : Entity<Enums.EventType>
    {
        public string Name { get; set; }
    }
}
