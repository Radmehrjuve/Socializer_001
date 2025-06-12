using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Socializer_001.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Socializer_001.Email_Service
{
    public class EmailSender : IEmailSender<ApplicationUser>
    {
        private readonly string smtpServer = "smtp.gmail.com";
        private readonly int smtpPort = 587; // 587 is recommended for STARTTLS
        private readonly string senderEmail = "socializerhelper@gmail.com";
        private readonly string senderPassword = "Heh, Biya Kire Mano Bokhor Akhe Ma.....e"; // Use App Password here
        public async Task SendEmailAsync(ApplicationUser user,string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(smtpServer, smtpPort)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };

             await client.SendMailAsync(new MailMessage(
                from: senderEmail,
                to: email,
                subject,
                htmlMessage));
        }

        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            var client = new SmtpClient(smtpServer, smtpPort)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };

            var to = email;
            var subject = "Confirm Your Email";
                var htmlMessage = $@"
            <p>Hello {user.UserName},</p>
            <p>Please confirm your email by clicking the link below:</p>
            <p><a href='{confirmationLink}'>Confirm Email</a></p>
            <p>If you did not request this, please ignore this email.</p>";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail, "Socializer Support"),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetlink)
        {
            //var client = new SendGridClient(config["SendGrid:ApiKey"]);
            //var from = new EmailAddress("newsradmehr@gmail.com", "Socializer");
            //var to = new EmailAddress(email);
            //var subject = "Reset Your Password";
            //var htmlmessage = $"<p>Please reset your password by clicking <a href=\"https://fast.com\"> here </a>. </p>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlmessage);
            //await client.SendEmailAsync(msg);
        }

        public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            //var client = new SendGridClient(config["SendGrid:ApiKey"]);
            //var from = new EmailAddress("newsradmehr@gmail.com", "Socializer");
            //var to = new EmailAddress(email);
            //var subject = "Password Reset Code";
            //var htmlMessage = $"<p>Your password reset code is: <strong>{resetCode}</strong></p>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            //await client.SendEmailAsync(msg);
        }
    }
}
