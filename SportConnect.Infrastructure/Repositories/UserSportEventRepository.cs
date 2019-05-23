using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class UserSportEventRepository : CrudRepository<UserSportEvent>, IUserSportEventRepository
    {
        public UserSportEventRepository(SportConnectContext context) : base(context)
        {
        }
    }
}
