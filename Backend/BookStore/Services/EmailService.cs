using BookStore.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace BookStore.Services
{
    public class EmailService(ILogger<EmailService> logger) : IEmailService
    {
        private readonly ILogger<EmailService> _logger = logger;

        public async Task SendConfirmationEmailToUser(
            string confirmationToken,
            string userName,
            string userEmail
        )
        {
            var confirmUrl = $"https://localhost:3000/register/confirm?={confirmationToken}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BookStore", "noreply@bookstore.com"));
            message.To.Add(new MailboxAddress(userName, userEmail));

            message.Subject = "Confirm your email address!";

            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = """
                    Hello {userName}

                    Please click the provided link to confirm your email address, once done you can log in and start using BookStore!

                    Confirm Email: {confirmUrl}

                    BookStore
                    """,
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("localhost", 1025);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }

        public Task SendResetPasswordEmailToUser(
            string resetToken,
            string userName,
            string userEmail
        )
        {
            throw new NotImplementedException();
        }
    }
}
