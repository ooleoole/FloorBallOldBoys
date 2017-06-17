using System.ComponentModel.DataAnnotations;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class EditUserViewModel
    {
        [Required(ErrorMessage = "Vänligen fyll i email")]
        [EmailAddress(ErrorMessage = "Vänligen fyll i en giltlig epost")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i förnamn")]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Förnamn:")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i efternamn")]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Efternamn:")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i personnummer")]
        [RegularExpression(@"^\d{8}-\d{4}$", ErrorMessage = "Tillåtet format är 12345678-1234")]
        [Display(Name = "Personnummer:")]
        public string SocialSecurityNumber { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i ort")]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Ort:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i gata")]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Gata:")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i postnummer")]
        [RegularExpression(@"^\d{3}\s{0,1}\d{2}\s{0,2}$", ErrorMessage = "Tillåtna format är 12345, 123 45")]
        [Display(Name = "Postnummer:")]
        public string ZipCode { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Lösenordet måste vara minst 6 tecken")]
        [Display(Name = "Nytt lösenord:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "Lösenorden matchar inte")]
        [MinLength(6, ErrorMessage = "Lösenordet måste vara minst 6 tecken")]
        [Display(Name = "Bekräfta lösenord:")]
        public string ConfirmPassword { get; set; }

        public bool? PasswordValidationState { get; set; }
    }
}