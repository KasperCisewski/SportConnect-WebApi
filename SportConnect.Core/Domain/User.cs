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
        public virtual IEnumerable<UserSportEvent> ConfirmedSportEvents { get; set; } = new List<UserSportEvent>();
        public int FavouriteSportTypeId { get; set; }
        public virtual SportType FavouriteSportType { get; set; }
        public Enums.Role UserRoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
