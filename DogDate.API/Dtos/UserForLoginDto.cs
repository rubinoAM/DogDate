using System.ComponentModel.DataAnnotations;

namespace DogDate.API.Dtos
{
    public class UserForLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}