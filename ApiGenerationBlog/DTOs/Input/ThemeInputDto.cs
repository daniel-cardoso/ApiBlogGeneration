using System.ComponentModel.DataAnnotations;
using ApiGenerationBlog.Validations.Attributes;

namespace ApiGenerationBlog.DTOs.Input;


public class ThemeInputDto
{
    [Required(ErrorMessage = "Required Field!")]
    [StringValidation(3)]
    public string Description { get; set; }
}