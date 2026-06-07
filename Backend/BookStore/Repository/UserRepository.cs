using BookStore.DbContexts;
using BookStore.Interfaces;
using BookStore.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
  public class UserRepository(ApplicationDbContext context) : IUserRepository
  {
    private readonly ApplicationDbContext _context = context;

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