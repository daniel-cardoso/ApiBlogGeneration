using ApiGenerationBlog.DataContext;
using ApiGenerationBlog.Models;
using ApiGenerationBlog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiGenerationBlog.Repository
{
    public class PostRepository:IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.Find(id);
        }

        public void Update(Post Post)
        {
            _context.Entry(Post).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
