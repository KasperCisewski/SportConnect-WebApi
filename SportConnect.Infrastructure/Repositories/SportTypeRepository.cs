using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class SportTypeRepository : CrudRepository<SportType>, ISportTypeRepository
    {
        public SportTypeRepository(SportConnectContext context) : base(context)
        {
        }
    }
}
