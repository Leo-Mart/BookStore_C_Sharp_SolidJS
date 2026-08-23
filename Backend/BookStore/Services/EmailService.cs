using BookStore.Models.Users;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;

namespace BookStore.Services
{
    public class EmailService(ILogger<EmailService> logger) : IEmailSender<AppUser>
    {
        private readonly ILogger<EmailService> _logger = logger;

        public async Task SendConfirmationLinkAsync(
            AppUser user,
            string email,
            string confirmationLink
        )
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BookStore", "noreply@bookstore.com"));
            message.To.Add(new MailboxAddress(user.FirstName, email));

            message.Subject = "Confirm your email address!";

            var bb = new BodyBuilder();

            bb.TextBody = $"""
                Hello {user.FirstName}

                Please click the provided link to confirm your email address, once done you can log in and start using BookStore!

                Confirm Email: {confirmationLink}

                BookStore
                """;

            bb.HtmlBody = $"""
                <h2>Hello {user.FirstName}<h2>

                Please click the provided link to confirm your email address, once done you can log in and start using BookStore!

                Confirm Email: <a href="{confirmationLink}">here</a>

                BookStore
                """;

            message.Body = bb.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("localhost", 1025);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }

        public Task SendPasswordResetCodeAsync(AppUser user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }

        public async Task SendPasswordResetLinkAsync(AppUser user, string email, string resetLink)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BookStore", "noreply@bookstore.com"));
            message.To.Add(new MailboxAddress(user.FirstName, email));

            message.Subject = "Password reset for account at Bookstore.com";

            var bb = new BodyBuilder();

            bb.TextBody = $"""
                Hello {user.FirstName}

                A password reset request has been sent for this email. If this wasn't you, changing your passwords might be wise.
                If this was intended, use the link below to reset your password, and make a new one.

                Reset link: {resetLink}

                BookStore
                """;

            bb.HtmlBody = $"""
                <h2>Hello {user.FirstName}<h2>
                A password reset request has been sent for this email. If this wasn't you, changing your passwords might be wise.
                If this was intended, use the link below to reset your password, and make a new one.

                Reset link: <a href="{resetLink}"here</a>

                BookStore
                """;

            message.Body = bb.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("localhost", 1025);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
