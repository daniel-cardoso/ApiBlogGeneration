using ApiGenerationBlog.DTOs.Input;
using ApiGenerationBlog.DTOs.Output;

namespace ApiGenerationBlog.Services.Interfaces
{
    public interface IUserService
    {
        Task <UserOutputDto?> GetById(int id);
        Task<IEnumerable<UserOutputDto?>> GetAll();
        Task<UserOutputDto> Add(UserInputDto userInputDto);
        Task<UserOutputDto> Update(UserInputDto userInputDto);
        Task Delete(int id);
    }
}
