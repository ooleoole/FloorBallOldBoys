using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class EllosOldBoysContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<UserTraningAttendance> UserTraningAttendance { get; set; }
        public DbSet<UserTraningEnrollment> UserTraningEnrollment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:oldboys.database.windows.net,1433;Initial Catalog=OldBoys;Persist Security Info=False;User ID=MUPPO;Password=OldBoys1337;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTraningAttendance>().HasKey(k => new {k.TrainingId, k.UserId});
            modelBuilder.Entity<UserTraningEnrollment>().HasKey(k => new {k.TrainingId, k.UserId});
            modelBuilder.Entity<User>().HasAlternateKey(k => k.Email);
            modelBuilder.Entity<Address>().HasAlternateKey(k => new {k.City, k.Street, k.ZipCode});
        }
    }
}