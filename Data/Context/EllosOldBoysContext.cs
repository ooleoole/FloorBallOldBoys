
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class EllosOldBoysContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Training> Tranings { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserTraningAttendance> UserTraningAttendances { get; set; }
        public DbSet<UserTraningEnrollment> UserTraningEnrollments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:oldboys.database.windows.net,1433;Initial Catalog=OldBoys;Persist Security Info=False;User ID=MUPPO;Password=OldBoys1337;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTraningAttendance>().HasKey(k => new { k.TraningId, k.UserId });
            modelBuilder.Entity<UserTraningEnrollment>().HasKey(k => new { k.TraningId, k.UserId });
        }
    }
}
