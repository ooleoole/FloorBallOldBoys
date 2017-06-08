using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.Utilites;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    [Route("api/account")]
    public class AccountControllerApi : Controller
    {
        private readonly UserManager<UserAccount> _userManger;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IUserService _userService;
        private readonly ISession _session;
        private User _loggedInUser;
        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        public AccountControllerApi(UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IUserService userService, ISession session)
        {
            _session = session;
            _userManger = userManager;
            _signInManager = signInManager;
            _userService = userService;

        }
        [HttpGet, Route("myAccount")]
        public IActionResult MyAccount()
        {
            var model = Mapper.ModelToViewModelMapping.UserToMyAccountViewModel(LoggedInUser);
            return PartialView("AccountDetails", model);
        }

        [HttpGet, Route("edit")]
        public IActionResult Edit(int id)
        {
            var user = _userService.FindAll(u => u.Id == id, "Address").FirstOrDefault();
            var model = Mapper.ModelToViewModelMapping.UserToEditUserViewModel(user);
            return PartialView(model);
        }
        [HttpPost, Route("edit")]
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
                return RedirectToAction("MyAccount", "AccountControllerApi");
            }
            return View(model);
        }

    }
}
