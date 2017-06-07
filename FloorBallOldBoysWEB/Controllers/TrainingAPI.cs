using Domain.Entities;
using Domain.Services;
using FloorBallOldBoysWEB.Utilites;
using Microsoft.AspNetCore.Mvc;

namespace FloorBallOldBoysWEB.Controllers
{
    public class TrainingApi : Controller
    {
        private readonly ITrainingService _trainingService;
        private readonly ISession _session;
        private User _loggedInUser;
        private User LoggedInUser => _loggedInUser ?? (_loggedInUser = _session.GetLoggedInUser(User.Identity.Name));

        public TrainingApi(ITrainingService trainingService, ISession session)
        {
            _session = session;
            _trainingService = trainingService;
        }
    }
}
