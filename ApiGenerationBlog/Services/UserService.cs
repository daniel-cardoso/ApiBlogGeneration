using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using ApiGenerationBlog.Services.Interfaces;

namespace ApiGenerationBlog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
