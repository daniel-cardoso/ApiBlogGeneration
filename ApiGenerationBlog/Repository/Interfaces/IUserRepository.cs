using ApiGenerationBlog.Models;

namespace ApiGenerationBlog.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<IEnumerable<User?>> GetAll();
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task Delete(int id);
    }
}
