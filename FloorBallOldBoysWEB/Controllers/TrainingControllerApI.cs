using System.Linq;
using Domain.Entities;
using Domain.Interfaces;
using FloorBallOldBoysWEB.Utilites;
using FloorBallOldBoysWEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    [Route("api/training")]
    [Route("")]
    public class TrainingControllerApi : Controller
    {
        private readonly ISession _session;
        private readonly ITrainingService _trainingService;
        private User _loggedInUser;

        public TrainingControllerApi(ITrainingService trainingService, ISession session)
        {
            _session = session;
            _trainingService = trainingService;
        }

        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        [HttpGet]
        [Route("createTraining")]
        [Authorize]
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [Route("createTraining")]
        [Authorize]
        public IActionResult Create(CreateTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Creator = LoggedInUser;
                var newTraning = Mapper.ViewModelToModelMapping.CreateTrainingViewModelToTraining(model);
                _trainingService.Add(newTraning);
                return RedirectToAction("GetAllTrainings");
            }
            return PartialView(model);
        }

        [HttpGet]
        [Route("todaysTrainings")]
        [Route("Start")]
        [Authorize]
        public IActionResult TodaysTrainings(bool isStartPage)
        {
            var todaysTranings = _trainingService.GetTodaysTrainings();
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(todaysTranings, LoggedInUser);

            if (isStartPage)
                return View("TodayTranings", model);


            return PartialView("TodayTranings", model);
        }

        [HttpGet]
        [Route("getAllTranings")]
        [Authorize]
        public IActionResult GetAllTrainings()
        {
            var allTrainings = _trainingService.AllInclude("EnrolledUsers.User", "ActualAttendance.User");
            var model = Mapper.ModelToViewModelMapping
                .TrainingsToTrainingsViewModel(allTrainings, LoggedInUser);
            return PartialView("AllTrainings", model);
        }

        [HttpGet]
        [Route("getTraining")]
        [Authorize]
        public IActionResult GetTraining(int trainingId)
        {
            var training = _trainingService.Find(trainingId, "EnrolledUsers.User", "ActualAttendance.User");
            var trainingSummaryViewModel =
                Mapper.ModelToViewModelMapping.TrainingToTrainingSummaryViewModel(training, LoggedInUser);
            return PartialView("_TrainingSummary", trainingSummaryViewModel);
        }

        [HttpPost]
        [Route("enrollTraining")]
        [Authorize]
        public IActionResult EnrollTraining(int trainingId)
        {
            var training = _trainingService.Find(trainingId);
            training.EnrolledUsers.Add(new UserTraningEnrollment
            {
                TrainingId = training.Id,
                UserId = LoggedInUser.Id
            });
            _trainingService.Update(training);
            training = _trainingService.Find(trainingId, "EnrolledUsers.User", "ActualAttendance.User");
            var trainingSummaryViewModel =
                Mapper.ModelToViewModelMapping.TrainingToTrainingSummaryViewModel(training, LoggedInUser);
            return PartialView("_TrainingSummary", trainingSummaryViewModel);
        }

        [HttpPost]
        [Route("dismissTraining")]
        [Authorize]
        public IActionResult DismissTraining(int trainingId)
        {
            var training = _trainingService.Find(trainingId, "EnrolledUsers.User", "ActualAttendance.User");
            var deleteEnrollments = training.EnrolledUsers.Where(ute => ute.UserId == LoggedInUser.Id).ToList();
            deleteEnrollments.ForEach(userTraningEnrollment => training.EnrolledUsers.Remove(userTraningEnrollment));
            _trainingService.Update(training);
            var trainingSummaryViewModel =
                Mapper.ModelToViewModelMapping.TrainingToTrainingSummaryViewModel(training, LoggedInUser);
            return PartialView("_TrainingSummary", trainingSummaryViewModel);
        }

        [HttpDelete]
        [Route("deleteTraining")]
        [Authorize]
        public IActionResult Delete(int trainingId)
        {
            var training = _trainingService.Find(trainingId);
            if (training is null)
                return BadRequest();

            _trainingService.Delete(training);
            return Ok();
        }

        [HttpGet]
        [Route("editTraining")]
        [Authorize]
        public IActionResult Edit(int trainingId)
        {
            var training = _trainingService.Find(trainingId);
            var model = Mapper.ModelToViewModelMapping.TrainingToTrainingViewModel(training);

            if (model is null)
                return BadRequest();


            return PartialView(model);
        }

        [HttpPost]
        [Route("editTraining")]
        [Authorize]
        public IActionResult Edit(EditTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var training = _trainingService.Find(model.TrainingId, "EnrolledUsers.User", "ActualAttendance.User");
                training = Mapper.ViewModelToModelMapping.EditTrainingViewModelToTraining(model, training);
                _trainingService.Update(training);
                var trainingSummaryViewModel =
                    Mapper.ModelToViewModelMapping.TrainingToTrainingSummaryViewModel(training, LoggedInUser);
                return PartialView("_TrainingSummary", trainingSummaryViewModel);
            }

            return PartialView(model);
        }

        [HttpPost]
        [Route("toggleTrainingStatus")]
        [Authorize]
        public IActionResult ToggleTrainingStatus(int trainingId, bool isCancelled)
        {
            var training = _trainingService.Find(trainingId, "EnrolledUsers.User", "ActualAttendance.User");
            training.IsCancelled = isCancelled;
            _trainingService.Update(training);
            var trainingSummaryViewModel =
                Mapper.ModelToViewModelMapping.TrainingToTrainingSummaryViewModel(training, LoggedInUser);
            return PartialView("_TrainingSummary", trainingSummaryViewModel);

        }
    }
}