using SportConnect.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportConnect.Core.Domain
{
    public class SportEvent : Entity<Guid>
    {

        public EventPlace EventPlace { get; set; }

        public EventType EventType { get; set; }

        public virtual IEnumerable<UserSportEvent> ConfirmedEventParticipant { get; set; } = new List<UserSportEvent>();

        public int MaximumNumberOfParticipants { get; set; } = 1000;

        public Enums.SportSkillLevel SportSkillLevelId { get; set; }
        public virtual SportSkillLevel ProposedEventSkillLevel { get; set; }

        public Guid SportEventManager { get; set; }
    }
}
