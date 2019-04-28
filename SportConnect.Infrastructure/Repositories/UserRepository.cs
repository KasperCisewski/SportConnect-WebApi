using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public IQueryable<User> GetAll()
        {
            return _context.User.AsQueryable();
        }

        public async Task<User> Get(Guid id)
        {
            return _context.User.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> Get(string email)
        {
            return _context.User.FirstOrDefault(u => u.Email == email);
        }

        public async Task Remove(Guid id)
        {
            var user = await Get(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
