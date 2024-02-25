using ApiGenerationBlog.Models;

namespace ApiGenerationBlog.Services.Interfaces
{
    public interface IPostService
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
    }
}
