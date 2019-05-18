using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DogDate.API.Data;
using DogDate.API.Models;
using DogDate.API.Dtos;

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
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDto)
        {
            //VALIDATION

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}