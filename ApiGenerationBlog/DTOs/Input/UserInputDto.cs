using System.ComponentModel.DataAnnotations;
using ApiGenerationBlog.Validations.Attributes;

namespace ApiGenerationBlog.DTOs.Input;

public class UserInputDto
{
    [Required(ErrorMessage = "Required Field!")]
    [StringValidation(3)]
    public required string Name { get; set; } 

    [Required(ErrorMessage = "Required Field!")]
    [EmailAddress]
    public required string Email { get; set; }

    public string? Photo { get; set; }
}