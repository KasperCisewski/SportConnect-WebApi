using Microsoft.EntityFrameworkCore;
using SportConnect.Core.Domain;

namespace SportConnect.Infrastructure.Data
{
    public class SportConnectContext : DbContext
    {
        private readonly SqlSettings _settings;
        public DbSet<User> Users { get; set; }
        public DbSet<SportEvent> SportEvents { get; set; }
        public DbSet<UserSportEvent> UserSportEvents { get; set; }

        public SportConnectContext(DbContextOptions<SportConnectContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSportEvent>()
                 .HasKey(use => new { use.UserId, use.SportEventId });
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
