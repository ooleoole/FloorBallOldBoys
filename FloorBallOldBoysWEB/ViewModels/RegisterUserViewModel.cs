﻿using System.ComponentModel.DataAnnotations;

namespace FloorBallOldBoysWEB.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Vänligen fyll i en giltlig epost")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Lösenordet måste vara minst 6 tecken")]
        [Display(Name = "Nytt lösenord:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Lösenorden matchar inte")]
        [MinLength(6, ErrorMessage = "Lösenordet måste vara minst 6 tecken")]
        [Display(Name = "Bekräfta lösenord:")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i förnamn")]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Förnamn")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Vänligen fyll i efternamn")]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Efternamn")]
        public string Lastname { get; set; }

        [Required]
        [RegularExpression(@"^\d{8}-\d{4}$", ErrorMessage = "Formatet är 12345678-1234")]
        [Display(Name = "Personnummer")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        [Display(Name = "Ort")]
        public string City { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Använd 2-35 tecken")]
        [MaxLength(35, ErrorMessage = "Använd 2-35 tecken")]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\s{0,1}\d{2}\s{0,2}$", ErrorMessage = "Tillåtna format är 12345, 123 45")]
        public string ZipCode { get; set; }
    }
}