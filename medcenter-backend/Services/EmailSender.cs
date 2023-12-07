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
