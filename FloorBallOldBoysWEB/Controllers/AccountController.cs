using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserAccount> _userManger;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IUserService _userService;

        public AccountController(UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IUserService userService)
        {

            _userManger = userManager;
            _signInManager = signInManager;
            _userService = userService;

        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
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
                    return RedirectToAction("TodaysTrainings", "Training");
                }
            }
            ModelState.AddModelError("", "Du gjorde sönder internet. Ring Pecka så fixar han det");
            return View(model);
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
                try
                {
                    _userService.Add(user);
                }
                catch (Exception)
                {
                    _userService.Delete(user);
                    ModelState.AddModelError("","Email upptagen");
                }
                

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
                    ModelState.AddModelError("", "Något fruktansvärt inträffade!" +
                                                 "Frågan är om du kommer att repa dig från dig från efterdyningarna från vad du nu ställt till med?" +
                                                 "Tveksamt. Dina familj och dina vänner kommer förkasta dig. Myndigheter kommer jaga dig. Inte ens din mor kommer vilja ha något med dig att göra" +
                                                 "En spetälsk nazist pedofil necrofil kommer känna sig mer välkommen i samhället än du..");
                    return View(model);
                }

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(userAccount, false);
                    return RedirectToAction("TodaysTrainings", "Training");
                }
                _userService.Delete(user);
                foreach (var error in createResult.Errors)
                    ModelState.AddModelError("", error.Description);

            }

            return View(model);
        }

    }
}
