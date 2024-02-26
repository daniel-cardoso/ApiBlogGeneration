using Microsoft.AspNetCore.Mvc;
using ApiGenerationBlog.Models;
using ApiGenerationBlog.Services.Interfaces;
using ApiGenerationBlog.DTOs;

namespace ApiGenerationBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            if (_userService.GetAll() == null)
            {
                return NotFound();
            }
            return Ok(_userService.GetAll().ToList());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            var user = _userService.GetById(id);

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] UserDTO userDTO)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }

            var usr = _userService.GetById(id);

            usr.Name = userDTO.Name;
            usr.Email = userDTO.Email;
            usr.Photo = userDTO.Photo;

            try
            {
                _userService.Update(usr);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(usr);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUser(UserDTO userDTO)
        {

            if(userDTO != null && EmailExists(userDTO.Email))
            {
                return BadRequest("Email existente");
            }
            var user = new User(userDTO.Name, userDTO.Email, userDTO.Photo);
            _userService.Add(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            _userService.Delete(id);
            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_userService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool EmailExists(string email)
        {
            return (_userService.GetAll()?.Any(e => e.Email == email)).GetValueOrDefault();
        }
    }
}
