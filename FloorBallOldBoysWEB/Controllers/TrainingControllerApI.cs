using System.Linq;
using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.Utilites;
using FloorBallOldBoysWEB.ViewModels;
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
        [HttpGet, Route("todaysTrainings")]
        [Authorize]
        public IActionResult TodaysTrainings()
        {

            var todaysTranings = _trainingService.GetTodaysTrainings();
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(todaysTranings, LoggedInUser, Url.Action(nameof(TodaysTrainings)));

            return PartialView("TodayTranings", model);
        }

        [HttpGet, Route("getAllTranings")]
        [Authorize]
        public IActionResult GetAllTrainings()
        {
            var allTrainings = _trainingService.AllInclude("EnrolledUsers.User", "ActualAttendance.User");
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(allTrainings, LoggedInUser, Url.Action(nameof(GetAllTrainings)));
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
            training = _trainingService.AllInclude("EnrolledUsers.User").
            FirstOrDefault(t => t.Id == trainingId);
            var trainingSummaryViewModel = Mapper.ModelToViewModelMapping.
                TrainingToTrainingSummaryViewModel(training, LoggedInUser, returnUrl);
            return PartialView("_TrainingSummary", trainingSummaryViewModel);
        }

        [HttpPost, Route("dismissTraining")]
        [Authorize]
        public IActionResult DismissTraining(int trainingId, string returnUrl)
        {
            var training = _trainingService.AllInclude("EnrolledUsers.User").FirstOrDefault(t => t.Id == trainingId);
            var deleteEnrollments = training.EnrolledUsers.Where(ute => ute.UserId == LoggedInUser.Id).ToList();
            deleteEnrollments.ForEach(userTraningEnrollment => training.EnrolledUsers.Remove(userTraningEnrollment));
            _trainingService.Update(training);
            var trainingSummaryViewModel = Mapper.ModelToViewModelMapping.
                 TrainingToTrainingSummaryViewModel(training, LoggedInUser, returnUrl);
            return PartialView("_TrainingSummary", trainingSummaryViewModel);
        }

        [HttpDelete, Route("deleteTraining")]
        [Authorize]
        public IActionResult Delete(int trainingId, string returnUrl)
        {
            var training = _trainingService.Find(trainingId);
            if (training is null)
                return BadRequest();

            _trainingService.Delete(training);
            return Ok();
        }

        [HttpGet, Route("editTraining")]
        [Authorize]
        public IActionResult Edit(int trainingId, string returnUrl)
        {
            var training = _trainingService.Find(trainingId);
            var model = Mapper.ModelToViewModelMapping.TrainingToTrainingViewModel(training);

            if (model is null)
                return Redirect(returnUrl);

            model.ReturnUrl = returnUrl;
            return PartialView(model);
        }

        [HttpPost, Route("editTraining")]
        [Authorize]
        public IActionResult Edit(EditTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var training = _trainingService.AllInclude("EnrolledUsers.User").FirstOrDefault(t => t.Id == model.TrainingId);
                training = Mapper.ViewModelToModelMapping.EditTrainingViewModelToTraining(model, training);
                _trainingService.Update(training);
                var trainingSummaryViewModel = Mapper.ModelToViewModelMapping.
                    TrainingToTrainingSummaryViewModel(training, LoggedInUser, model.ReturnUrl);
                return PartialView("_TrainingSummary", trainingSummaryViewModel);
            }

            return PartialView(model);
        }


    }
}
