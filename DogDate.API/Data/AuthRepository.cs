using System.Threading.Tasks;
using DogDate.API.Models;

namespace DogDate.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        public Task<User> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}