using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class EventPlaceRepository : CrudRepository<EventPlace>, IEventPlaceRepository
    {
        public EventPlaceRepository(SportConnectContext context) : base(context)
        {
        }
    }
}
