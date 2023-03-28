using System.Net.Mail;
using System.Linq;

namespace EmailSender
{
    public class MailMessageFactory
    {
        public static MailMessage Get(Contracts.MailMessage message)
        {
            var smtpMessage = new System.Net.Mail.MailMessage
            {
                Subject = message.Subject,
                From = new MailAddress(message.From.Address, message.From.DisplayName),
                IsBodyHtml = message.IsBodyHtml,
                Priority = message.Priority,
                Body = message.Body
            };

            message.To.ToList().ForEach(x => smtpMessage.To.Add(x));
            message.Cc?.ToList().ForEach(x => smtpMessage.To.Add(x));
            message.Bcc?.ToList().ForEach(x => smtpMessage.To.Add(x));

            return smtpMessage;
        }
    }
}
