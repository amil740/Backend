using Pustok.Services.Interfaces;

namespace Pustok.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            await Task.CompletedTask;
            _logger.LogInformation($"Email sent to {to} with subject: {subject}");
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetLink)
        {
            var subject = "Password Reset Request";
            var body = $@"
      <h2>Password Reset Request</h2>
    <p>You have requested to reset your password. Please click the link below:</p>
            <a href='{resetLink}'>Reset Password</a>
<p>If you did not request this, please ignore this email.</p>
  ";
            await SendEmailAsync(email, subject, body);
        }

        public async Task SendWelcomeEmailAsync(string email, string userName)
        {
            var subject = "Welcome to Pustok!";
            var body = $@"
        <h2>Welcome {userName}!</h2>
    <p>Thank you for registering at Pustok.</p>
  <p>We're excited to have you with us!</p>
 ";
            await SendEmailAsync(email, subject, body);
        }
    }
}
