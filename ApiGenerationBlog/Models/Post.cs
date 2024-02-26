using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGenerationBlog.Models
{
    public class Post
    {

        public Post()
        {
            //this.User = new User();
            this.Theme = new Theme();
            this.Date = DateTime.Now;
        }

        public Post(string title, string text, User user, Theme theme)
        {
            this.Title = title;
            this.Text = text;
            this.User = user;
            this.Theme = theme;
            this.Date = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MinLength(5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MinLength(10)]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Theme")]
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
    }
}