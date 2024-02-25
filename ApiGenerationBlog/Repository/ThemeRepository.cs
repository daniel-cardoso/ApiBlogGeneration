using ApiGenerationBlog.DataContext;
using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGenerationBlog.Repository
{
    public class ThemeRepository:IThemeRepository
    {
        private readonly AppDbContext _context;

        public ThemeRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public void Add(Theme theme)
        {
            _context.Themes.Add(theme);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var theme = _context.Themes.Find(id);
            if (theme != null)
            {
                _context.Themes.Remove(theme);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Theme> GetAll()
        {
            return _context.Themes.ToList();
        }

        public Theme GetById(int id)
        {
            return _context.Themes.Find(id);
        }

        public void Update(Theme theme)
        {
            _context.Entry(theme).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
