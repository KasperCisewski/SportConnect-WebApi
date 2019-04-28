using SportConnect.Core.Domain.Base;
using System;

namespace SportConnect.Core.Domain
{
    public class Message : Entity<Guid>
    {
        public string MessageContent { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid SportEventId { get; set; }
        public SportEvent SportEvent { get; set; }
    }
}
