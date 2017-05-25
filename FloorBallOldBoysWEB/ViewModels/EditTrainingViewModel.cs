using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class EditTrainingViewModel
    {
        [Required]
        public int Id { get; set; }
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
        [Display(Name = "Inställd")]
        public bool IsCancelled { get; set; }
        public string ReturnUrl { get; set; }
    }
}
