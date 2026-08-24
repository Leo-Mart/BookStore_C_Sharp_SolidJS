using BookStore.Models.Users;

namespace BookStore.Interfaces
{
    public interface IAccountService
    {
        Task RegisterNewUser(RegisterDto registerDto);
        Task LoginUser(LoginDto loginDto);
        Task RefreshAccessToken();
        Task LogoutUser(RefreshTokenDto refreshDto);
        Task ChangeUserPassword(string userId, string oldPassword, string newPassword);
        Task GeneratePasswordResetTokenForUser(string email);
        Task ResetUserPassword(string email, string passwordResetToken, string newPassword);
        Task GenerateEmailConfirmationTokenForUser(string email);
        Task ConfirmUserEmail(string email, string emailConfirmationToken);
    }
}
