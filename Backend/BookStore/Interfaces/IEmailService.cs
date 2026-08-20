namespace BookStore.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmailToUser(
            string confirmationTokenstring,
            string userName,
            string userEmail
        );
        Task SendResetPasswordEmailToUser(string resetToken, string userName, string userEmail);
    }
}
