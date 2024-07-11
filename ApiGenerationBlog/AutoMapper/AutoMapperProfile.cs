using ApiGenerationBlog.DTOs.Input;
using ApiGenerationBlog.DTOs.Output;
using ApiGenerationBlog.DTOs.Update;
using ApiGenerationBlog.Models;
using AutoMapper;

namespace ApiGenerationBlog.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ThemeInputDto, Theme>(); 
        CreateMap<ThemeUpdateDto, Theme>();
        CreateMap<Theme, ThemeOutputDto>();
    }
}