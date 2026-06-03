using someboeoeks.Models.Users;

namespace someboeoeks.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int userId);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> UserExistsAsync(int userId);
    }
}