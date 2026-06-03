using Microsoft.EntityFrameworkCore;
using someboeoeks.DbContexts;
using someboeoeks.Interfaces;
using someboeoeks.Models.Users;

namespace someboeoeks.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetUserByIdAsync(int userId)
    {
      return await _context.Users.Include(r => r.Reviews).Where(u => u.Id == userId).FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
      return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task<bool> UserExistsAsync(int userId)
    {
      return await _context.Users.AnyAsync(u => u.Id == userId);
    }
  }
}