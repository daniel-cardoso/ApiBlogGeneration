using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using ApiGenerationBlog.Services.Interfaces;

namespace ApiGenerationBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetById(int id)
        {
            return _postRepository.GetById(id);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
