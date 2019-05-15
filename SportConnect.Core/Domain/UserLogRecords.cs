using SportConnect.Core.Domain.Base;
using System;

namespace SportConnect.Core.Domain
{
    public class UserLogRecords : Entity<int>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
