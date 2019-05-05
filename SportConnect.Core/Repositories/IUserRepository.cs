using System;
using System.Linq;
using System.Threading.Tasks;
using SportConnect.Core.Domain;

namespace SportConnect.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(Guid id);
        Task<User> Get(string email);
        Task Remove(Guid id);
        Task AddNewLogRecord(Guid userId);
    }
}
