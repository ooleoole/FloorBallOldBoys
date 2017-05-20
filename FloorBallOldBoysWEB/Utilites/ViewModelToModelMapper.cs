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
            trainingToBeEdited.Info = model.Info;
            trainingToBeEdited.IsCancelled = model.IsCancelled;
            return trainingToBeEdited;
        }
    }
}