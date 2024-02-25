using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGenerationBlog.Models
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Campo Obrigatório!")]
        [MinLength(3)]
        public string Description { get; set; }

        [InverseProperty("Theme")]
        public ICollection<Post> Posts { get; set; }

    }
}