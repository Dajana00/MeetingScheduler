using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeetingScheduler.Service
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPassword;

        public EmailService()
        {
            _smtpServer = "smtp.gmail.com";
            _smtpPort = 587;
            _smtpUser = "dajanaskocajic18@gmail.com";
            _smtpPassword = "";
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var fromAddress = new MailAddress(_smtpUser, "Meeting Scheduler App");
            var toAddress = new MailAddress(toEmail);
            using (var smtp = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtp.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                smtp.EnableSsl = true;

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    await smtp.SendMailAsync(message);
                }
            }
        }
    }

}
