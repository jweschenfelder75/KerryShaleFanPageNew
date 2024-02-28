using System.Net;
using System.Net.Mail;
using de.jweschenfelder.KSFP.Web.Interfaces.MailAndSmsServices;
using de.jweschenfelder.KSFP.Web.Interfaces.Security;

namespace KerryShaleFanPage.Server.Services.MailAndSmsServices
{
    public class GmailMailAndSmsService : IGmailMailAndSmsService
    {
        private readonly ISecuredConfigurationService _securedConfigurationService;

        private const string _SMS_PREFIX = "[kerryshalefanpg-sms]";
        private const string _HOSTNAME = "smtp.gmail.com";
        private const int _PORT = 587;

        private readonly ILogger<GmailMailAndSmsService> _logger;  // TODO: Implement logging!

        /// <summary>
        /// 
        /// </summary>
        public GmailMailAndSmsService(ILogger<GmailMailAndSmsService> logger, ISecuredConfigurationService securedConfigurationService)
        {
            _logger = logger;
            _securedConfigurationService = securedConfigurationService;
        }

        /// <inheritdoc cref="IMailAndSmsService"/>
        public bool SendMailNotification(string from, string to, string subject, string? message)
        {
            if (string.IsNullOrWhiteSpace(from))
            {
                from = "kerryshalefanpage@gmail.com";
            }

            if (string.IsNullOrWhiteSpace(to))
            {
                to = "kerryshalefanpage@gmail.com";
            }

            using var client = new SmtpClient
            {
                Timeout = 60000,
                Host = _HOSTNAME,
                Port = _PORT,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("kerryshalefanpage@gmail.com", "vrxn czlf souw tsff")   // TODO: Make configurable!
            };

            using var mail = new MailMessage(from, to)
            {
                Subject = subject,
                Body = message ?? string.Empty
            };

            try
            {
                client.Send(mail);
                return true;
            }
            catch (SmtpException ex)
            {
                var smtpException = ex;  // TODO: Log exception!
            }

            return false;
        }

        /// <inheritdoc cref="IMailAndSmsService"/>
        public bool SendSmsNotification(string from, string to, string subject, string? message)
        {
            return SendMailNotification(from, to, $"{_SMS_PREFIX} {subject}", message);
        }
    }
}
