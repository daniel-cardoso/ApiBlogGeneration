using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGenerationBlog.DataContext;
using ApiGenerationBlog.Models;
using ApiGenerationBlog.Services.Interfaces;
using ApiGenerationBlog.Services;
using ApiGenerationBlog.DTOs;

namespace ApiGenerationBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly IThemeService _themeService;

        public ThemesController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        // GET: api/Themes
        [HttpGet]
        public IActionResult GetThemes()
        {
            if (_themeService.GetAll() == null)
            {
                return NotFound();
            }
            return Ok(_themeService.GetAll().ToList());
        }

        // GET: api/Themes/5
        [HttpGet("{id}")]
        public IActionResult GetTheme(int id)
        {
            if (!ThemeExists(id))
            {
                return NotFound();
            }
            var thm = _themeService.GetById(id);

            return Ok(thm);
        }

        // PUT: api/Themes/5
        [HttpPut("{id}")]
        public IActionResult PutTheme(int id, ThemeDTO themeDTO)
        {
            if (!ThemeExists(id))
            {
                return NotFound();
            }

            var thm = _themeService.GetById(id);

            thm.Description = themeDTO.Description;

            try
            {
                _themeService.Update(thm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(thm);
        }

        // POST: api/Themes
        [HttpPost]
        public IActionResult PostTheme(ThemeDTO themeDTO)
        {
            if (themeDTO.Description.Trim().Length < 3)
            {
                return BadRequest("Description minimum lenght: 3");
            }
            var theme = new Theme();
            theme.Description = themeDTO.Description.Trim();
            _themeService.Add(theme);
            return CreatedAtAction("GetTheme", new { id = theme.Id }, theme);
        }

        // DELETE: api/Themes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTheme(int id)
        {
            if (!ThemeExists(id))
            {
                return NotFound();
            }
            _themeService.Delete(id);
            return NoContent();
        }

        private bool ThemeExists(int id)
        {
            return (_themeService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
