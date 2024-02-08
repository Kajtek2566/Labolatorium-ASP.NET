using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3_v2.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać login!")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Proszę podać email!")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać Nr.Telefnu!")]
        [Display(Name = "Numer Telefonu")]
        [Phone]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public ISet<PostEntity> Posts { get; set; }
    }
}
