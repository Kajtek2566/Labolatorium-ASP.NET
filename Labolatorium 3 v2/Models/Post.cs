using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labolatorium_3_v2.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać zawartość postu!")]
        [Display(Name = "Content")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Proszę podać Autora!")]
        [Display(Name = "Autor")]
        public string? Autor { get; set; }

        [HiddenInput]
        
        public DateTime? Publication_date { get; set; } = DateTime.Now;

       
        [Display(Name = "Tagi")]
        public string? Tags { get; set; }

        
        [Display(Name = "Komentarz")]
        public string? Comment { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        [HiddenInput]
        public int UserId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Users { get; set; }


    }
}
