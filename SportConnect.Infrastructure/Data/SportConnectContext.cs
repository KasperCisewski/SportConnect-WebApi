using Microsoft.EntityFrameworkCore;
using SportConnect.Core.Domain;

namespace SportConnect.Infrastructure.Data
{
    public class SportConnectContext : DbContext
    {
        private readonly SqlSettings _settings;
        public DbSet<User> User { get; set; }
        public DbSet<SportEvent> SportEvent { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<UserSportEvent> UserSportEvent { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<EventPlace> EventPlace { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SportSkillLevel> SportSkillLevel { get; set; }
        public DbSet<SportType> SportType { get; set; }
        public DbSet<UserLogRecords> UserLogRecords { get; set; }

        public SportConnectContext(DbContextOptions<SportConnectContext> options, 
            SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasKey(use => new { use.UserId, use.SportEventId });

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(se => se.Messages)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.SportEvent)
                .WithMany(se => se.Messages)
                .HasForeignKey(m => m.SportEventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSportEvent>()
                 .HasKey(use => new { use.UserId, use.SportEventId });

            modelBuilder.Entity<UserSportEvent>()
             .HasOne(m => m.User)
             .WithMany(se => se.ConfirmedSportEvents)
             .HasForeignKey(m => m.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSportEvent>()
                .HasOne(m => m.SportEvent)
                .WithMany(se => se.ConfirmedEventParticipants)
                .HasForeignKey(m => m.SportEventId)
                .OnDelete(DeleteBehavior.Restrict);
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
