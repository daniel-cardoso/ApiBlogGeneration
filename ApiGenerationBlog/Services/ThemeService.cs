using ApiGenerationBlog.DTOs.Input;
using ApiGenerationBlog.DTOs.Output;
using ApiGenerationBlog.DTOs.Update;
using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using ApiGenerationBlog.Services.Interfaces;
using AutoMapper;

namespace ApiGenerationBlog.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _themeRepository;
        private readonly IMapper _mapper;


        public ThemeService(IThemeRepository themeRepository, IMapper mapper)
        {
            _themeRepository = themeRepository;
            _mapper = mapper;
        }

        public async Task<ThemeOutputDto?> GetById(int id)
        {
            var theme = await _themeRepository.GetById(id);

            return _mapper.Map<ThemeOutputDto?>(theme);
        }

        public async Task<IEnumerable<ThemeOutputDto?>> GetAll()
        {
            if (!_themeRepository.GetAll().Result.Any())
                return Enumerable.Empty<ThemeOutputDto>();

            var themes = await _themeRepository.GetAll();
            var themesOutputDto = _mapper.Map<IEnumerable<ThemeOutputDto>>(themes);
            return themesOutputDto;
        }

        public async Task<ThemeOutputDto> Add(ThemeInputDto themeInputDto)
        {
            var themeModel = _mapper.Map<Theme>(themeInputDto);
            var temp = await _themeRepository.Add(themeModel);

            var themeOutputDto = _mapper.Map<ThemeOutputDto>(temp);
            return themeOutputDto;
        }

        public async Task<ThemeOutputDto> Update(int id, ThemeUpdateDto themeUpdateDto)
        {
            //var themeModel = _mapper.Map<Theme>(themeUpdateDto, opt => opt.Items["Id"] = id);
            var themeModel = _mapper.Map<Theme>(themeUpdateDto, opt => opt.AfterMap((src, dest) => { dest.Id = id; }));
            var temp = await _themeRepository.Update(themeModel);
            var themeOutputDto = _mapper.Map<ThemeOutputDto>(temp);
            return themeOutputDto;
        }

        public async Task Delete(int id)
        {
            await _themeRepository.Delete(id);
        }

        // TODO: VER SE VOU USAR ESSE MÉTODO NA CONTROLLER OU AQUI NA SERVICE
        /*private bool ThemeExists(int id)    
        {
            return _themeRepository.GetAll().Result.Any(e => e.Id == id);
        }*/
    }
}