using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class SportEventRepository : CrudRepository<SportEvent>, ISportEventRepository
    {
        public SportEventRepository(SportConnectContext context) : base(context)
        {

        }
    }
}
