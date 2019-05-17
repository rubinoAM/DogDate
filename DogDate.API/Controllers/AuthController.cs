using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DogDate.API.Data;
using DogDate.API.Models;

namespace DogDate.API.Controllers
{
    [Route("api/[controller]")] //http://localhost:5000/api/values
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            //VALIDATION

            username = username.ToLower();

            if(await _repo.UserExists(username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = username
            };

            var createdUser = await _repo.Register(userToCreate, password);

            return StatusCode(201);
        }
    }
}