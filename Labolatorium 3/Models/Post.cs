using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Prosze wpisać zawartość!")]
        [Display(Name ="Zawartość")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Prosze podać Autora!")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Prosze podać datę publikacji!")]
        [Display(Name = "Data publikacji")]
        public DateTime DateOfPublication { get; set; }

        [Required(ErrorMessage = "Prosze podać Tagi")]
        [Display(Name = "Tagi")]
        public string Tags { get; set; }

        [Required(ErrorMessage = "Prosze podać komentarz")]
        [Display(Name = "Komentarz")]
        public string Comment { get; set; }

        public PostContact Owner { get; set; } = default!;

        [HiddenInput]
        public DateTime? Created { get; set; }

    }
}
