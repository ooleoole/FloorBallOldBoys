using System.Linq;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.IdentityUser;
using Microsoft.AspNetCore.Identity;

namespace FloorBallOldBoysWEB.Utilites
{


    public class Session : ISession
    {

        private readonly IUserService _userService;
        private readonly UserManager<UserAccount> _userManager;



        public Session(IUserService userService, UserManager<UserAccount> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public User GetLoggedInUser(string userName)
        {
            var loggedInUserId = _userManager.Users.FirstOrDefault(u => u.UserName == userName).UserId;
            return _userService.AllInclude(p => p.Address).FirstOrDefault(u => u.Id == loggedInUserId);
        }
    }
}
