using ApiGenerationBlog.DTOs.Input;
using ApiGenerationBlog.DTOs.Output;
using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using ApiGenerationBlog.Services.Interfaces;
using AutoMapper;

namespace ApiGenerationBlog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserOutputDto?> GetById(int id)
        {
            var userOutputDto = await _userRepository.GetById(id);
            return _mapper.Map<UserOutputDto>(userOutputDto);
        }

        public async Task<IEnumerable<UserOutputDto?>> GetAll()
        {
            if (!_userRepository.GetAll().Result.Any())
                return Enumerable.Empty<UserOutputDto>();

            var users = await _userRepository.GetAll();
            var usersOutputDto = _mapper.Map<IEnumerable<UserOutputDto>>(users);
            return usersOutputDto;
        }

        public async Task<UserOutputDto> Add(UserInputDto userInputDto)
        {
            var userModel = _mapper.Map<User>(userInputDto);
            var temp = await _userRepository.Add(userModel);
            var userOutputDto = _mapper.Map<UserOutputDto>(temp);
            return userOutputDto;
        }

        public async Task<UserOutputDto> Update(UserInputDto userInputDto)
        {
            var userModel = _mapper.Map<User>(userInputDto);
            var temp = await _userRepository.Update(userModel);
            var userOutputDto = _mapper.Map<UserOutputDto>(temp);
            return userOutputDto;
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}