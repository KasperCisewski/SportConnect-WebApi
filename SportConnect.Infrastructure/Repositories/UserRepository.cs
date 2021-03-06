﻿using SportConnect.Core.Domain;
using SportConnect.Core.Repositories;
using SportConnect.Infrastructure.Data;

namespace SportConnect.Infrastructure.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(SportConnectContext context) : base(context)
        {
        }
    }
}
