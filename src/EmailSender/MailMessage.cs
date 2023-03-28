using System.Net.Mail;

namespace EmailSender.Contracts
{
    public class MailAddress
    {
        public string Address { get; set; }
        public string? DisplayName { get; set; }

        public MailAddress()
        {
        }

        public MailAddress(string address)
        {
            Address = address;
        }

        public MailAddress(string address, string displayName)
        {
            Address = address;
            DisplayName = displayName;
        }
    }
    public class MailMessage
    {
        public MailAddress From { get; set; }
        public ICollection<string> To { get; } = new List<string>();
        public ICollection<string> Cc { get; } = new List<string>();
        public ICollection<string> Bcc { get; } = new List<string>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public MailPriority Priority { get; set; } = MailPriority.Normal;
    }
}
