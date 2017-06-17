using System;
using System.ComponentModel.DataAnnotations;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class EditTrainingViewModel
    {
        [Required]
        public int TrainingId { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i plats")]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Plats")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Vänligen ange starttid")]
        [Display(Name = "Starttid")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Vänligen ange sluttid")]
        [Display(Name = "Sluttid")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Vänligen ange datum")]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [MaxLength(512, ErrorMessage = "Max längd 512 tecken")]
        [DataType(DataType.MultilineText)]
        public string Info { get; set; }

        [Display(Name = "Ställ in")]
        public bool IsCancelled { get; set; }
    }
}