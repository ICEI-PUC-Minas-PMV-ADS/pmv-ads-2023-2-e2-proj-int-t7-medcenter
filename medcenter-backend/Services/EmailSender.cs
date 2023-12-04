using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace medcenter_backend.Services
{
    public class EmailSender
    {
        public async Task SendEmail(string subject, string toEmail, string username, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("medcenterinforme@gmail.com", "Medcenter");
            var to = new EmailAddress(toEmail, username);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
