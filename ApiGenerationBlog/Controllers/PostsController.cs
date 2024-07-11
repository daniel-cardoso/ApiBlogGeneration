// using Microsoft.AspNetCore.Mvc;
// using ApiGenerationBlog.Models;
// using ApiGenerationBlog.Services.Interfaces;
// using ApiGenerationBlog.DTOs;
//
// namespace ApiGenerationBlog.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class PostsController : ControllerBase
//     {
//         private readonly IPostService _postService;
//         private readonly IUserService _userService;
//         private readonly IThemeService _themeService;
//
//
//         public PostsController(IPostService postService, IUserService userService, IThemeService themeService)
//         {
//             _postService = postService;
//             _userService = userService;
//             _themeService = themeService;
//         }
//
//         // GET: api/Posts
//         [HttpGet]
//         public IActionResult GetPosts()
//         {
//             if (_postService.GetAll() == null)
//             {
//                 return NotFound();
//             }
//             return Ok(_postService.GetAll().ToList());
//         }
//
//         // GET: api/Posts/5
//         [HttpGet("{id}")]
//         public IActionResult GetPost(int id)
//         {
//             if (!PostExists(id))
//             {
//                 return NotFound();
//             }
//             var post = _postService.GetById(id);
//
//             return Ok(post);
//         }
//
//         // PUT: api/Posts/5
//         [HttpPut("{id}")]
//         public IActionResult PutPost(int id, PostDTO postDTO)
//         {
//             if (!PostExists(id))
//             {
//                 return NotFound();
//             }
//
//             var pst = _postService.GetById(id);
//
//             pst.Title = postDTO.Title;
//             pst.Text = postDTO.Text;
//             pst.ThemeId = postDTO.ThemeId.Value;
//
//             try
//             {
//                 _postService.Update(pst);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex);
//             }
//
//             var post = _postService.GetById(id);
//
//
//             return Ok(post);
//         }
//
//         // POST: api/Posts
//         [HttpPost]
//         public IActionResult PostPost(PostDTO postDTO)
//         {
//             var thm = _themeService.GetById(postDTO.ThemeId.Value);
//             var usr = _userService.GetById(postDTO.UserId.Value);
//             
//             
//             if(thm != null && usr != null && !string.IsNullOrWhiteSpace(postDTO.Text) && !string.IsNullOrWhiteSpace(postDTO.Title))
//             {
//                 var post = new Post(postDTO.Title,postDTO.Text,usr,thm);
//                 _postService.Add(post);
//                 return CreatedAtAction("GetPost", new { id = post.Id }, post);
//             }
//
//             return BadRequest();
//             
//         }
//
//         // DELETE: api/Posts/5
//         [HttpDelete("{id}")]
//         public IActionResult DeletePost(int id)
//         {
//             if (!PostExists(id))
//             {
//                 return NotFound();
//             }
//             _postService.Delete(id);
//             return NoContent();
//         }
//
//         private bool PostExists(int id)
//         {
//             return (_postService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
//         }
//     }
// }
