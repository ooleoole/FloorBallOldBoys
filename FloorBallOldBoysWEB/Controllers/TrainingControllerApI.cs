using System.Linq;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    [Route("api/training")]
    public class TrainingControllerApi : Controller
    {
        private readonly ITrainingService _trainingService;
        private readonly ISession _session;
        private User _loggedInUser;
        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        public TrainingControllerApi(ITrainingService trainingService, ISession session)
        {
            _session = session;
            _trainingService = trainingService;
        }

        [HttpGet, Route("getAllTranings")]
        [Authorize]
        public IActionResult GetAllTrainings()
        {

            var allTrainings = _trainingService.AllInclude("EnrolledUsers.User", "ActualAttendance.User");
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(allTrainings, LoggedInUser);
            model.ReturnUrl = Url.Action(nameof(GetAllTrainings));
            return PartialView("AllTrainings", model);
        }
        [HttpPost, Route("enrollTraining")]
        [Authorize]
        public IActionResult EnrollTraining(int trainingId, string returnUrl)
        {
            var training = _trainingService.Find(trainingId);
            training.EnrolledUsers.Add(new UserTraningEnrollment
            {
                TrainingId = training.Id,
                UserId = LoggedInUser.Id
            });
            _trainingService.Update(training);
            return Redirect(returnUrl);
        }

        [HttpPost, Route("dismissTraining")]
        [Authorize]
        public IActionResult DismissTraining(int trainingId, string returnUrl)
        {
            var training = _trainingService.AllInclude("EnrolledUsers.User").FirstOrDefault(t => t.Id == trainingId);
            var deleteEnrollments = training.EnrolledUsers.Where(ute => ute.UserId == LoggedInUser.Id).ToList();
            deleteEnrollments.ForEach(de => training.EnrolledUsers.Remove(de));
            _trainingService.Update(training);
            return Redirect(returnUrl);
        }

    }
}
