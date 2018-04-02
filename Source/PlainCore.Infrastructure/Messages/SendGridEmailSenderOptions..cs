using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Infrastructure.Messages
{
    public class SendGridEmailSenderOptions
    {
        public string ApiKey { get; set; }
        public string DefaultSenderEmail { get; set; }
        public string DefaultSenderName { get; set; }
    }
}
