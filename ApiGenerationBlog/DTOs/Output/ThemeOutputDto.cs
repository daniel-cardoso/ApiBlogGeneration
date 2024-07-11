namespace ApiGenerationBlog.DTOs.Output;

public record ThemeOutputDto
{
    public int Id { get; set; }
    public string Description { get; init; }
}