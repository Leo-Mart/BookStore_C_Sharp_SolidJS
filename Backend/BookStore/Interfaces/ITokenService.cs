using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}