using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using FloorBallOldBoysWEB.ViewModels;

namespace FloorBallOldBoysWEB.Utilites
{
    internal class ModelToViewModelMapper
    {
        public TrainingsViewModel TrainingsToTrainingsViewModel(
            IEnumerable<Training> trainings, User loggedInUser)
        {
            return new TrainingsViewModel
            {
                TrainingsSummaryViewModels = TrainingsToTrainingsSummaryViewModels(trainings, loggedInUser)


            };
        }

        public EditTrainingViewModel TrainingToTrainingViewModel(Training training)
        {
            return new EditTrainingViewModel
            {
                TrainingId = training.Id,
                Date = training.Date.Date,
                StartTime = training.StartTime,
                EndTime = training.EndTime,
                Info = training.Info,
                Location = training.Location,
                IsCancelled = training.IsCancelled
            };
        }

        public EditUserViewModel UserToEditUserViewModel(User user)
        {
            return new EditUserViewModel
            {
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                City = user.Address.City,
                Street = user.Address.Street,
                ZipCode = user.Address.ZipCode,
                SocialSecurityNumber = user.SocialSecurityNumber


            };
        }

        public AccountDetailsViewModel UserToMyAccountViewModel(User user)
        {
            return new AccountDetailsViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                City = user.Address.City,
                Street = user.Address.Street,
                ZipCode = user.Address.ZipCode,
                SocialSecurityNumber = user.SocialSecurityNumber

            };
        }

        public TrainingSummaryViewModel TrainingToTrainingSummaryViewModel(Training training, User loggedInUser)
        {
            return new TrainingSummaryViewModel
            {
                TrainingId = training.Id,
                StartTime = training.StartTime,
                EndTime = training.EndTime,
                Date = training.Date,
                Location = training.Location,
                IsCancelled = training.IsCancelled,
                Info = training.Info,
                CreatorId = training.CreatorId,
                Creator = training.Creator,
                EnrolledUsers = training.EnrolledUsers,
                IsAdmin = loggedInUser.IsAdmin,
                


            };
        }

        public IEnumerable<TrainingSummaryViewModel> TrainingsToTrainingsSummaryViewModels
            (IEnumerable<Training> trainings, User loggedInUser)
        {
            return trainings.Select(t => TrainingToTrainingSummaryViewModel(t, loggedInUser));
        }
    }


}