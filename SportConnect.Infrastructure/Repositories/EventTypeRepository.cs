using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportConnect.Infrastructure.Repositories
{
    public class EventTypeRepository : CrudRepository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(SportConnectContext context) : base(context)
        {
        }
    }
}
