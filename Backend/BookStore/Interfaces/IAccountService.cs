using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface IAccountService
    {
        Task<AuthResponse> GetMe(string userId);
        Task RegisterNewUser(RegisterDto registerDto);
        Task<AuthResponse> LoginUser(LoginDto loginDto);
        Task RefreshAccessToken();
        Task LogoutUser();
        Task ChangeUserPassword(string userId, string oldPassword, string newPassword);
        Task GeneratePasswordResetTokenForUser(string email);
        Task ResetUserPassword(string email, string passwordResetToken, string newPassword);
        Task GenerateEmailConfirmationTokenForUser(string email);
        Task ConfirmUserEmail(string email, string emailConfirmationToken);
    }
}
