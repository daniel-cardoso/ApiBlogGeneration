namespace ApiGenerationBlog.DTOs.Output;

public record UserOutputDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public string? Photo { get; init; }
}