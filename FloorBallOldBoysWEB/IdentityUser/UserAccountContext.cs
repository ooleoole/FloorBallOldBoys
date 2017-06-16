using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FloorBallOldBoysWEB.IdentityUser
{
    public class UserAccountContext : IdentityDbContext<UserAccount>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:oldboys.database.windows.net,1433;Initial Catalog=OldBoys;Persist Security Info=False;User ID=MUPPO;Password=OldBoys1337;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserAccount>().HasOne(x => x.User);
            modelBuilder.Entity<UserTraningAttendance>().HasKey(k => new {k.TrainingId, k.UserId});
            modelBuilder.Entity<UserTraningEnrollment>().HasKey(k => new {k.TrainingId, k.UserId});
            modelBuilder.Entity<User>().HasAlternateKey(k => k.Email);
            modelBuilder.Entity<Address>().HasAlternateKey(k => new {k.City, k.Street, k.ZipCode});
        }
    }
}