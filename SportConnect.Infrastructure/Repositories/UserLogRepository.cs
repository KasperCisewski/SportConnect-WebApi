using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class UserLogRepository : CrudRepository<UserLogRecords>, IUserLogRecordRepository
    {
        public UserLogRepository(SportConnectContext context) : base(context)
        {
        }
    }
}
