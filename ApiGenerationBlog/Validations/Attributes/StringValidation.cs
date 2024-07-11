using System.ComponentModel.DataAnnotations;

namespace ApiGenerationBlog.Validations.Attributes;

public class StringValidation : ValidationAttribute
{
    // private readonly string _value;
    private readonly int _size;

    public StringValidation(int size)
    {
        // _value = value;
        _size = size;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {


        if (string.IsNullOrWhiteSpace(value?.ToString()))
            return new ValidationResult("The field is null or whitespace.");

        if (value.ToString()!.Trim().Length < _size)
            return new ValidationResult($"{_size} is the minimum length for this field.");

        if (value is not null && value is string)
        {
            var trimmedValue = value.ToString().Trim();
            var property = validationContext.ObjectType.GetProperty(validationContext.MemberName);

            if (property is not null && property.CanWrite)
            {
                property.SetValue(validationContext.ObjectInstance, trimmedValue);
            }
        }

        return ValidationResult.Success;
    }
}