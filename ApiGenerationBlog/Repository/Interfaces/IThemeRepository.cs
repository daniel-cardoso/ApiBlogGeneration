using ApiGenerationBlog.Models;

namespace ApiGenerationBlog.Repository.Interfaces
{
    public interface IThemeRepository
    {
        Task<Theme?> GetById(int id);
        Task<IEnumerable<Theme?>> GetAll();
        Task<Theme?> Add(Theme theme);
        Task<Theme> Update(Theme theme);
        Task Delete(int id);
    }
}
