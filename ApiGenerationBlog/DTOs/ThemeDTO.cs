using System.ComponentModel.DataAnnotations;

namespace ApiGenerationBlog.DTOs
{
    public class ThemeDTO
    {
        [Required(ErrorMessage = "Required Field!")]
        [MinLength(3,ErrorMessage ="Minimum lenght: 3!")]
        public string Description { get; set; }
    }
}
