using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace EmailSender.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private static IConfiguration _Configuration { get; set; }
        public EmailSenderController(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        [HttpPost]
        [Route("sendEmail")]
        public void SendEmail(Contracts.MailMessage Request)
        {
            var host = _Configuration["smtpHost"];
            var port = Convert.ToInt16(_Configuration["smtpport"]);

            using (var mailMessage = MailMessageFactory.Get(Request))
            using (var smtpClient = new SmtpClient(host, port))
            {
                smtpClient.Send(mailMessage);

            }
        }
    }
}
