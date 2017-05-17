using System;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class CreateTrainingViewModel
    {
        [Required]
        [Display(Name = "Plats")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Starttid")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Sluttid")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Info { get; set; }
        public Admin Creator { get; set; }

    }
}
