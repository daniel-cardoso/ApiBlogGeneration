using ApiGenerationBlog.Models;

namespace ApiGenerationBlog.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
