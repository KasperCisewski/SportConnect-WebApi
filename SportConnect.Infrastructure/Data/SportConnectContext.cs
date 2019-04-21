using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SportConnect.Core.Domain;

namespace SportConnect.Infrastructure.Data
{
    public class SportConnectContext : DbContext
    {
        private readonly SqlSettings _settings;
        public DbSet<User> Users { get; set; }

        public SportConnectContext(DbContextOptions<SportConnectContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            if (_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();
                return;
            }

            optionsBuilder.UseSqlServer(_settings.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
