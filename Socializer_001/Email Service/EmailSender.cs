using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Socializer_001.Email_Service
{
    public class EmailSender : IEmailSender<IdentityUser>
    {
        private readonly mailersend
        public EmailSender(IConfiguration cng)
        {
            config = cng;          
        }

        public async Task SendEmailAsync(IdentityUser user,string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(config["SendGrid:ApiKey"]);
            var from = new EmailAddress("newsradmehr@gmail.com", "Socializer");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);

            await client.SendEmailAsync(msg);
        }

        public async Task SendConfirmationLinkAsync(IdentityUser user, string email, string confirmationLink)
        {
            var client = new SendGridClient(config["SendGrid:ApiKey"]);
            var from = new EmailAddress("newsradmehr@gmail.com", "Socializer");
            var to = new EmailAddress(email);
            var subject = "Confirm Your Email";
            var htmlMessage = $"<p>Please confirm your email by clicking <a href=\"{confirmationLink}\">here</a>.</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            await client.SendEmailAsync(msg);
        }

        public async Task SendPasswordResetLinkAsync(IdentityUser user, string email, string resetlink)
        {
            var client = new SendGridClient(config["SendGrid:ApiKey"]);
            var from = new EmailAddress("newsradmehr@gmail.com", "Socializer");
            var to = new EmailAddress(email);
            var subject = "Reset Your Password";
            var htmlmessage = $"<p>Please reset your password by clicking <a href=\"https://fast.com\"> here </a>. </p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlmessage);
            await client.SendEmailAsync(msg);
        }

        public async Task SendPasswordResetCodeAsync(IdentityUser user, string email, string resetCode)
        {
            var client = new SendGridClient(config["SendGrid:ApiKey"]);
            var from = new EmailAddress("newsradmehr@gmail.com", "Socializer");
            var to = new EmailAddress(email);
            var subject = "Password Reset Code";
            var htmlMessage = $"<p>Your password reset code is: <strong>{resetCode}</strong></p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            await client.SendEmailAsync(msg);
        }
    }
}
