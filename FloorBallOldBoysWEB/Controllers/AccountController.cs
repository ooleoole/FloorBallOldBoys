using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.IdentitUser;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserAccount> _userManger;
        private SignInManager<UserAccount> _signInManager;
        private IUserService _userService;

        public AccountController(UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IUserService userService)
        {

            _userManger = userManager;
            _signInManager = signInManager;
            _userService = userService;

        }

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password,
                    model.RememberMe, false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
                return RedirectToAction("TodaysTranings", "Traning");

            }
            ModelState.AddModelError("", "Could not login");
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Address = new Address
                    {
                        City = model.City,
                        Street = model.Street,
                        ZipCode = model.ZipCode
                    },
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    SocialSecurityNumber = model.SocialSecurityNumber,
                };
                _userService.Add(user);
                var userAccount = new UserAccount
                {
                    UserName = model.Email,
                    UserId = user.Id
                };
                IdentityResult createResult;
                try
                {
                    createResult = await _userManger.CreateAsync(userAccount, model.Password);
                }
                catch (Exception)
                {
                    _userService.Delete(user);
                    throw;
                }

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(userAccount, false);
                    return RedirectToAction("TodaysTranings", "Traning");
                }
                _userService.Delete(user);
                foreach (var error in createResult.Errors)
                    ModelState.AddModelError("", error.Description);

            }

            return View();
        }

    }
}
