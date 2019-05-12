using SportConnect.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportConnect.Core.Domain
{
    public class SportEvent : Entity<Guid>
    {
        public string EventName { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime EventEndTime { get; set; }
        public int SportTypeId { get; set; }
        public virtual SportType SportType { get; set; }
        public EventPlace EventPlace { get; set; }
        public EventType EventType { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; } = new List<Message>();
        public virtual IEnumerable<UserSportEvent> ConfirmedEventParticipants { get; set; } = new List<UserSportEvent>();
        public int MinimumNumberOfParticipants { get; set; } = 2;
        public int MaximumNumberOfParticipants { get; set; } = 1000;
        public Enums.SportSkillLevel SportSkillLevelId { get; set; }
        public virtual SportSkillLevel ProposedEventSkillLevel { get; set; }
        public Guid SportEventManagerId { get; set; }
    }
}
