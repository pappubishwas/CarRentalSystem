using System.Threading.Tasks;
using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public interface IUserService
    {
        Task<User> RegisterUser(User user);
        string AuthenticateUser(User user);
    }
}
