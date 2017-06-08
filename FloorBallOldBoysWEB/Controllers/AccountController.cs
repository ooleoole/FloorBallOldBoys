using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
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
        private readonly ISession _session;
        private User _loggedInUser;
        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        public AccountController(UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IUserService userService, ISession session)
        {
            _session = session;
            _userManger = userManager;
            _signInManager = signInManager;
            _userService = userService;

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

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
                    return RedirectToAction("TodaysTrainings", "Training");
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
                    await _signInManager.SignInAsync(userAccount, false);
                    return RedirectToAction("TodaysTrainings", "Training");
                }
                if (user.Id != 0)
                    _userService.Delete(user);


                foreach (var error in createResult.Errors)
                    ModelState.AddModelError("", error.Description);

            }

            return View(model);
        }

        //public IActionResult MyAccount()
        //{
        //    var model = Mapper.ModelToViewModelMapping.UserToMyAccountViewModel(LoggedInUser);
        //    return View("AccountDetails", model);
        //}
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var user = _userService.FindAll(u => u.Id == id, "Address").FirstOrDefault();
        //    var model = Mapper.ModelToViewModelMapping.UserToEditUserViewModel(user);
        //    return View(model);
        //}
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // var userAccount = _userManger.Users.FirstOrDefault(u => u.UserId == LoggedInUser.Id);

                //await _userManger.RemovePasswordAsync(userAccount);
                //var result = await _userManger.AddPasswordAsync(userAccount, model.Password);
                //if (!result.Succeeded)
                //{
                //    foreach (var error in result.Errors)
                //        ModelState.AddModelError("", error.Description);

                //    return View(model);
                //}
                var user = Mapper.ViewModelToModelMapping.EditUserViewModelToUser(model, LoggedInUser);
                _userService.Update(user);
                return RedirectToAction("MyAccount","AccountControllerApi");
            }
            return View(model);
        }
    }
}
