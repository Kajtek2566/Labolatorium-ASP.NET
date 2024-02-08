using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public ISet<PostEntity> Posts { get; set; }

    }
}
