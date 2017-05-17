using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage ="Vänligen fyll i förnamn"), Range(2,35,ErrorMessage = "Använd 2-35 tecken"), Display(Name = "Förnamn")]
        public string Firstname { get; set; }
        [Required, Range(2, 35, ErrorMessage = "Använd 2-35 tecken"), Display(Name = "Efternamn")]
        public string Lastname { get; set; }
        [Required, EmailAddress(ErrorMessage = "Vänligen fyll i en giltlig epost"), Display(Name = "Email")]
        public string Email { get; set; }
        [Required, RegularExpression(@"^\d{8}-\d{4}$",ErrorMessage = "Formatet är xxxxxxxxx-xxxx")]
        public string SocialSecurityNumber { get; set; }
    }
}
