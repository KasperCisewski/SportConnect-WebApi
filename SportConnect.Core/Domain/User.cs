using SportConnect.Core.Domain.Base;
using System;
using System.Collections.Generic;

namespace SportConnect.Core.Domain
{
    public class User : Entity<Guid>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FavouriteSportTypeId { get; set; }
        public virtual SportType FavouriteSportType { get; set; }
        public Enums.Role RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual IEnumerable<UserSportEvent> ConfirmedSportEvents { get; set; } = new List<UserSportEvent>();
        public virtual IEnumerable<Message> Messages { get; set; } = new List<Message>();
        public virtual IEnumerable<UserLogRecords> UserLogRecords { get; set; }
    }
}
