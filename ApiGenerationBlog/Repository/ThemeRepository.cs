using ApiGenerationBlog.DataContext;
using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGenerationBlog.Repository
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly AppDbContext _context;

        public ThemeRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Theme> Add(Theme theme)
        {
            await _context.Themes.AddAsync(theme);
            await _context.SaveChangesAsync();
            return theme;
        }

        public async Task Delete(int id)
        {
            var theme = await _context.Themes.FindAsync(id);
            if (theme != null)
            {
                _context.Themes.Remove(theme);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Theme?>> GetAll()
        {
            return await _context.Themes.ToListAsync();
        }

        public async Task<Theme?> GetById(int id)
        {
            //TODO ENTENDER O CONTEXTO DO TRACKING DE ENTIDADES E COMO IREI ABORDAR 
            //return await _context.Themes.FindAsync(id);
            return await _context.Themes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Theme> Update(Theme theme)
        {
            _context.Attach(theme);
            _context.Entry(theme).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return theme;
        }
    }
}
