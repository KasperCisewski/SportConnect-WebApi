using System;
using System.Linq;
using System.Threading.Tasks;
using SportConnect.Core.Domain;

namespace SportConnect.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> Get(Guid id);
        Task<User> Get(string email);
        IQueryable<User> GetAll();
        Task Add(User user);
        Task Update(User user);
        Task Remove(Guid id);
        Task AddNewLogRecord(Guid userId);
    }
}
