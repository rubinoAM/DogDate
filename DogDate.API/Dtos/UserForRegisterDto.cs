using System.ComponentModel.DataAnnotations;

namespace DogDate.API.Dtos
{
    public class UserForRegisterDTO
    {
        [Required]
        [StringLength(16,MinimumLength = 6,ErrorMessage = "You must specify a username between 6 and 16 characters.")]
        public string Username { get; set; }
        
        [Required]
        [StringLength(25,MinimumLength = 8,ErrorMessage = "You must specify a password between 8 and 25 characters.")]
        public string Password { get; set; }
    }
}