using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using ApiGenerationBlog.Services.Interfaces;

namespace ApiGenerationBlog.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _themeRepository;

        public ThemeService(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        public void Add(Theme theme)
        {
            _themeRepository.Add(theme);
        }

        public void Delete(int id)
        {
            _themeRepository.Delete(id);
        }

        public IEnumerable<Theme> GetAll()
        {
            return _themeRepository.GetAll();
        }

        public Theme GetById(int id)
        {
            return _themeRepository.GetById(id);
        }

        public void Update(Theme theme)
        {
            _themeRepository.Update(theme);
        }
    }
}
