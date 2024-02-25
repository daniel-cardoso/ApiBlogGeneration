using ApiGenerationBlog.Models;

namespace ApiGenerationBlog.Repository.Interfaces
{
    public interface IPostRepository
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
    }
}
