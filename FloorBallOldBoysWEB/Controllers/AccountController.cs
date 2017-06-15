using System;
using System.Threading.Tasks;
using Domain.Services;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.Utilites;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                Response.Redirect("/Start?isStartPage=True");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
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
                    return Redirect("/Start?isStartPage=True");
                }
            }
            ModelState.AddModelError("", "Du gjorde sönder internet. Ring Pecka så fixar han det");
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.ViewModelToModelMapping.RegisterUserViewModelToUser(model);

                try
                {
                    _userService.Add(user);
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Email upptagen");
                    return View(model);
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
                    await _signInManager.SignInAsync(userAccount, true);
                    return Redirect("/Start?isStartPage=True");
                }
                if (user.Id != 0)
                    _userService.Delete(user);


                foreach (var error in createResult.Errors)
                    ModelState.AddModelError("", error.Description);

            }

            return View(model);
        }



    }
}
