using System.Threading.Tasks;
using CarRentalSystem.Models;
using CarRentalSystem.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CarRentalSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly string _jwtKey = "YourSecretKeyHere123"; 

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> RegisterUser(User user)
        {
            await _userRepo.AddUser(user);
            return user;
        }

        public string AuthenticateUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new System.Security.Claims.Claim("id", user.Id.ToString()) }),
                Expires = System.DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
