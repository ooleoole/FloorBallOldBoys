using System.Collections.Generic;
using Domain.Entities;
using FloorBallOldBoysWEB.IdentityUser;
using FloorBallOldBoysWEB.ViewModels;

namespace FloorBallOldBoysWEB.Utilites
{
    internal class ModelToViewModelMapper
    {
        public TrainingsViewModel TrainingsToTrainingsViewModel(
            IEnumerable<Training> todaysTranings, User loggedInUser)
        {
            return new TrainingsViewModel
            {
                Tranings = todaysTranings,
                IsAdmin = loggedInUser.IsAdmin

            };
        }

        public EditTrainingViewModel TrainingToTrainingViewModel(Training training)
        {
            return new EditTrainingViewModel
            {
               Id=training.Id,
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
                City =user.Address.City,
                Street = user.Address.Street,
                ZipCode = user.Address.ZipCode,
                SocialSecurityNumber = user.SocialSecurityNumber
                
                
            };
        }

        public MyAccountViewModel UserToMyAccountViewModel(User user)
        {
            return new MyAccountViewModel
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
    }


}