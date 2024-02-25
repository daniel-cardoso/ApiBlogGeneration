using ApiGenerationBlog.Models;

namespace ApiGenerationBlog.Services.Interfaces
{
    public interface IThemeService
    {
        Theme GetById(int id);
        IEnumerable<Theme> GetAll();
        void Add(Theme theme);
        void Update(Theme theme);
        void Delete(int id);
    }
}
