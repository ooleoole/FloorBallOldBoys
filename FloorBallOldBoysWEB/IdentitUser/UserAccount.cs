using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FloorBallOldBoysWEB.IdentitUser
{
    public class UserAccount : IdentityUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
         
    }
}
