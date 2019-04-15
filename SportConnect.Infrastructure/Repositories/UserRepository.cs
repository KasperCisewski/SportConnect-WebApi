using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;

namespace SportConnect.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        public Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(string email)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
