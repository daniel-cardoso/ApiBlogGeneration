using System.ComponentModel.DataAnnotations;

namespace ApiGenerationBlog.DTOs
{
    public class PostDTO
    {
        [Required(ErrorMessage = "Required Field!")]
        [MinLength(5, ErrorMessage = "Minimum lenght: 5!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MinLength(10, ErrorMessage = "Minimum lenght: 10!")]
        public string Text { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int? ThemeId {  get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? UserId { get; set; }
    }
}
