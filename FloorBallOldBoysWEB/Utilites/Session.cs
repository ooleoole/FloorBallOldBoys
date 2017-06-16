using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using FloorBallOldBoysWEB.IdentityUser;
using Microsoft.AspNetCore.Identity;

namespace FloorBallOldBoysWEB.Utilites
{
    public class Session : ISession
    {
        private readonly UserManager<UserAccount> _userManager;

        private readonly IUserService _userService;


        public Session(IUserService userService, UserManager<UserAccount> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public User GetLoggedInUser(string userName)
        {
            var loggedInUserId = _userManager.Users.FirstOrDefault(u => u.UserName == userName).UserId;
            return _userService.FindAll(u => u.Id == loggedInUserId, p => p.Address).FirstOrDefault();
        }
    }
}