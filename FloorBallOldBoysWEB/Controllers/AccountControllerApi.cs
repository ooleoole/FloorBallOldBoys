using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.Utilites;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FloorBallOldBoysWEB.Controllers
{
    [Route("api/account")]
    public class AccountControllerApi : Controller
    {
        private readonly ISession _session;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly UserManager<UserAccount> _userManger;
        private readonly IUserService _userService;
        private User _loggedInUser;

        public AccountControllerApi(UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager,
            IUserService userService, ISession session)
        {
            _session = session;
            _userManger = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        [HttpGet]
        [Route("myAccount")]
        public IActionResult MyAccount()
        {
            var model = Mapper.ModelToViewModelMapping.UserToMyAccountViewModel(LoggedInUser);
            return PartialView("AccountDetails", model);
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(int id)
        {
            var user = _userService.FindAll(u => u.Id == id, "Address").FirstOrDefault();
            var model = Mapper.ModelToViewModelMapping.UserToEditUserViewModel(user);
            return PartialView(model);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userAccount = _userManger.Users.FirstOrDefault(u => u.UserId == LoggedInUser.Id);
                if (!string.IsNullOrEmpty(model.Password))
                {
                    //var userAccount = _userManger.Users.FirstOrDefault(u => u.UserId == LoggedInUser.Id);
                    await _userManger.RemovePasswordAsync(userAccount);
                    var result = await _userManger.AddPasswordAsync(userAccount, model.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError("", error.Description);

                        return PartialView(model);
                    }
                }
                
                var user = Mapper.ViewModelToModelMapping.EditUserViewModelToUser(model, LoggedInUser);
                _userService.Update(user);
                return RedirectToAction("MyAccount", "AccountControllerApi");
            }
            model.PasswordValidationState = GetPasswordValidationState();
            return PartialView(model);
        }

        private bool GetPasswordValidationState()
        {
            return ModelState.Where(items => items.Key == "Password" || items.Key == "ConfirmPassword")
                .All(items => items.Value.ValidationState != ModelValidationState.Invalid);
        }
    }
}