using ApiGenerationBlog.Validations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ApiGenerationBlog.DTOs.Input;

public class PostInputDto
{
    [Required(ErrorMessage = "Required Field!")]
    [StringValidation(5)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Required Field!")]
    [StringValidation(5)]
    public string Text { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? ThemeId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? UserId { get; set; }
}