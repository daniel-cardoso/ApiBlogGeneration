using System.ComponentModel.DataAnnotations;

namespace ApiGenerationBlog.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Required Field!")]
        [MinLength(3, ErrorMessage = "Minimum lenght: 3!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [EmailAddress]
        public string Email { get; set; }

        public string? Photo { get; set; }

    }
}
