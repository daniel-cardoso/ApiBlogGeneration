using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGenerationBlog.Models
{
    public class User
    {
        public User(string name, string email, string? photo)
        {
            this.Name = name;
            this.Email = email;
            this.Photo = photo;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Required Field!")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Required Field!")]
        [EmailAddress]
        [Index(IsUnique=true)]
        public string Email { get; set; }

        
        public string? Photo { get; set; }

    }
}
