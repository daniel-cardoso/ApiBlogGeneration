namespace ApiGenerationBlog.DTOs.Output;

public record PostOutputDto
{
    public string Title { get; init; }
    public string Text { get; init; }
    public int? ThemeId { get; set; }
    public int? UserId { get; set; }
}