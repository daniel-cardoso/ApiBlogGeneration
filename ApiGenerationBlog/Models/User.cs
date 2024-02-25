using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGenerationBlog.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Campo Obrigatório!")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }

        public string Photo { get; set; }

        [InverseProperty("User")]
        public ICollection<Post> Posts { get; set; }
    }
}
