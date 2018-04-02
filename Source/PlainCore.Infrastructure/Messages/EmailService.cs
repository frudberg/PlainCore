using PlainCore.Core.Externals.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PlainCore.Infrastructure.Messages
{
    public class EmailService : IEmailSender
    {
        private IOptions<SendGridEmailSenderOptions> emailSenderOptions;

        public EmailService(IOptions<SendGridEmailSenderOptions> emailSenderOptions)
        {
            this.emailSenderOptions = emailSenderOptions;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(emailSenderOptions.Value.ApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(emailSenderOptions.Value.DefaultSenderEmail, emailSenderOptions.Value.DefaultSenderName),
                Subject = subject,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
