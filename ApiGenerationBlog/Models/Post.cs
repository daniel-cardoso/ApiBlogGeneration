using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGenerationBlog.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório!")]
        [MinLength(5)]
        public string Title { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório!")]
        [MinLength(10)]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Theme")]
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
    }
}