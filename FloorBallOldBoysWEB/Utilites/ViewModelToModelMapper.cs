using System;
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

        public User EditUserViewModelToUser(EditUserViewModel model, User userToBeEdited)
        {
            userToBeEdited.Address.City = model.City;
            userToBeEdited.Address.Street = model.Street;
            userToBeEdited.Address.ZipCode = model.ZipCode;
            userToBeEdited.Firstname = model.Firstname;
            userToBeEdited.Lastname = model.Lastname;
            userToBeEdited.SocialSecurityNumber = model.SocialSecurityNumber;
            return userToBeEdited;
        }

        public User RegisterUserViewModelToUser(RegisterUserViewModel model)
        {
            return new User
            {
                Address = new Address
                {
                    City = model.City,
                    Street = model.Street,
                    ZipCode = model.ZipCode
                },
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                SocialSecurityNumber = model.SocialSecurityNumber
            };
        }

        public Training CreateTrainingViewModelToTraining(CreateTrainingViewModel model)
        {
            return new Training
            {
                Location = model.Location,
                StartTime = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.StartTime.Hour,
                    model.StartTime.Minute, 0),
                EndTime = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, model.EndTime.Hour,
                    model.EndTime.Minute, 0),
                Date = model.Date,
                Info = model.Info,
                CreatorId = model.Creator.Id
            };
        }
    }
}