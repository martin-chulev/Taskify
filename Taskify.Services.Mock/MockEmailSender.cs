using Microsoft.AspNetCore.Identity.UI.Services;

namespace Taskify.Services.Mock
{
    public class MockEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"Sending email to: {email}, Subject: {subject}");
            return Task.CompletedTask;
        }
    }
}
