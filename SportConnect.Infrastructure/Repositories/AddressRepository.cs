using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class AddressRepository : CrudRepository<Address>, IAddressRepository
    {
        public AddressRepository(SportConnectContext context) : base(context)
        {
        }
    }
}
