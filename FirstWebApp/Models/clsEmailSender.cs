using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace FirstWebApp.Models
{
    public class clsEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string fMail = "mahmoud-div@outlook.com";
            string fAppPassword = "TestingPassword" ;

            var message = new MailMessage();
            message.From = new MailAddress(fMail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fMail, fAppPassword)
            };
            smtpClient.Send(message);
        }
    }
}
