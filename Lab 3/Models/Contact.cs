using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab_3.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Imię jest wymagane.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane.")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email.")]
        public string Email { get; set; }
    }
}
