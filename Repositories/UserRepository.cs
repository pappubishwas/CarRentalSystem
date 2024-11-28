using System.Threading.Tasks;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly CarRentalDbContext _context;

        public UserRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> GetUserById(int id) => await _context.Users.FindAsync(id);
    }
}
