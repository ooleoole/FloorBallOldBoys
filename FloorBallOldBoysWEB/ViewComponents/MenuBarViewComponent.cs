using System.Linq;
using System.Threading;
using Domain.Services;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.ViewComponents
{
    public class MenuBarViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly UserManager<UserAccount> _userManager;

        public MenuBarViewComponent(IUserService userService, UserManager<UserAccount> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).UserId;


            var loogedInUser = _userService.Find(userId);
            var model= new MenuBarViewModel
            {
                Email = loogedInUser.Email,
                IsAdmin = loogedInUser.IsAdmin,
                Name =$"{loogedInUser.Firstname} {loogedInUser.Lastname}"
            };

            return View(model);
        }
    }
}