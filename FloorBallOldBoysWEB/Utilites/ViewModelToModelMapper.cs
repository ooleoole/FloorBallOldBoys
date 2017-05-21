using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using FloorBallOldBoysWEB.ViewModels;

namespace FloorBallOldBoysWEB.Utilites
{
    internal class ViewModelToModelMapper
    {
        public Training EditTrainingViewModelToTraining(EditTrainingViewModel model, Training trainingToBeEdited)
        {
            trainingToBeEdited.EndTime = model.EndTime;
            trainingToBeEdited.StartTime = model.StartTime;
            trainingToBeEdited.Date = model.Date;
            trainingToBeEdited.Location = model.Location;
            trainingToBeEdited.Info = model.Info;
            trainingToBeEdited.IsCancelled = model.IsCancelled;
            return trainingToBeEdited;
        }

        public User EditUserViewModelToUser(EditUserViewModel model,User userToBeEdited)
        {
            userToBeEdited.Address.City = model.City;
            userToBeEdited.Address.Street = model.Street;
            userToBeEdited.Address.ZipCode = model.ZipCode;
            userToBeEdited.Firstname = model.Firstname;
            userToBeEdited.Lastname = model.Lastname;
            userToBeEdited.SocialSecurityNumber = model.SocialSecurityNumber;
            return userToBeEdited;

        }
    }
}