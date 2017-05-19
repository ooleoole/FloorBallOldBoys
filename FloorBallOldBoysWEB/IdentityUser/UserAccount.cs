using Domain.Entities;

namespace FloorBallOldBoysWEB.IdentityUser
{
    public class UserAccount : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser
    {

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
