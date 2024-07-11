using Microsoft.AspNetCore.Mvc;
using ApiGenerationBlog.Services.Interfaces;
using ApiGenerationBlog.DTOs.Input;
using ApiGenerationBlog.DTOs.Update;

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
        public async Task<ActionResult> GetThemes()
        {
            try
            {
                return Ok(await _themeService.GetAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        // GET: api/Themes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTheme(int id)
        {
            try
            {
                var thm = await _themeService.GetById(id);
                if (thm is null) return NotFound();

                return Ok(thm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        // POST: api/Themes
        [HttpPost]
        public async Task<ActionResult> PostTheme(ThemeInputDto themeInputDto)
        {
            try
            {
                var themeOutputDto = await _themeService.Add(themeInputDto);
                return CreatedAtAction("GetTheme", new {id = themeOutputDto.Id}, themeOutputDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        // PUT: api/Themes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTheme(int id, ThemeUpdateDto themeUpdateDto)
        {
            try
            {
                var thm = await _themeService.GetById(id);
                if (thm is null)
                    return NotFound();

                var themeOutputDto = await _themeService.Update(id, themeUpdateDto);
                return Ok(themeOutputDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        // DELETE: api/Themes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTheme(int id)
        {
            try
            {
                var thm = await _themeService.GetById(id);
                if (thm is null)
                    return NotFound();

                await _themeService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        //TODO: VOU USAR OU VOU DELETAR? 
        /*private bool ThemeExists(int id)
        {
            return _themeService.GetAll().Result.Any(e => e.Id == id);
        }*/
    }
}