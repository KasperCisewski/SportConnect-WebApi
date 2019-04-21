using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SportConnectContext _context;

        public UserRepository(SportConnectContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> Get(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task Remove(Guid id)
        {
            var user = await Get(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
