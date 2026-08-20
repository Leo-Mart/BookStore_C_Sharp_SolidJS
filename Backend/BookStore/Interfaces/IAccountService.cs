using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface IAccountService
    {
        Task<AuthResponse> RegisterNewUser(RegisterDto registerDto);
        Task<AuthResponse> LoginUser(LoginDto loginDto);
        Task<AuthResponse> RefreshAccessToken(RefreshTokenDto refreshDto);
        Task LogoutUser(RefreshTokenDto refreshDto);
        Task<bool> ChangeUserPassword(string userId, string oldPassword, string newPassword);
        Task<bool> GeneratePasswordResetTokenForUser(string email);
        Task<bool> ResetUserPassword(string email, string passwordResetToken, string newPassword);
        Task<bool> GenerateEmailConfirmationTokenForUser(string email);
        Task<bool> ConfirmUserEmail(string email, string emailConfirmationToken);
    }
}
