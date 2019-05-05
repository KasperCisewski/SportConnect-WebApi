using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(SportConnectContext context) : base(context)
        {
        }

        public async Task AddNewLogRecord(Guid userId)
        {
            _context.UserLogRecords.Add(new UserLogRecords
            {
                UserId = userId
            });
            await _context.SaveChangesAsync();
        }
    }
}
