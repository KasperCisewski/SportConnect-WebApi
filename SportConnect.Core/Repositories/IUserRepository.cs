using System;
using System.Linq;
using System.Threading.Tasks;
using SportConnect.Core.Domain;

namespace SportConnect.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddNewLogRecord(Guid userId);
    }
}
