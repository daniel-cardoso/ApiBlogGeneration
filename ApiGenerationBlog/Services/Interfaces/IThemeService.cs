using ApiGenerationBlog.DTOs.Input;
using ApiGenerationBlog.DTOs.Output;
using ApiGenerationBlog.DTOs.Update;

namespace ApiGenerationBlog.Services.Interfaces
{
    public interface IThemeService
    {
        Task<ThemeOutputDto?> GetById(int id);
        Task<IEnumerable<ThemeOutputDto?>> GetAll();
        Task<ThemeOutputDto> Add(ThemeInputDto themeInputDto);
        Task<ThemeOutputDto> Update(int id, ThemeUpdateDto themeUpdateDto);
        Task Delete(int id);
    }
}
