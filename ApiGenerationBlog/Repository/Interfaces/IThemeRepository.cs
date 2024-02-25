using ApiGenerationBlog.Models;

namespace ApiGenerationBlog.Repository.Interfaces
{
    public interface IThemeRepository
    {
        Theme GetById(int id);
        IEnumerable<Theme> GetAll();
        void Add(Theme theme);
        void Update(Theme theme);
        void Delete(int id);
    }
}
