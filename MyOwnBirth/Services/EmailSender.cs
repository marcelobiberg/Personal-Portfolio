using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyOwnBirth.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        //Hotmail :smtp.live.com - 587
        private SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        private MailMessage mailMessage = new MailMessage();

        public Task SendEmailAsync(string email, string subject, string message, string name, string phone)
        {
            //Seta para falso e adiciona seu email e senha
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("seuGmail@gmail.com", "suasenha");
            client.EnableSsl = true;

            //Cria a messagem do email
            mailMessage.From = new MailAddress("seuGmail@gmail.com");
            mailMessage.Subject = subject;
            mailMessage.Body = "Email de:" + email + "!" + Environment.NewLine + message + Environment.NewLine + name + " | " + phone;
            mailMessage.To.Add(new MailAddress("seuGmail@gmail.com"));

            //Envia a mensagem
            client.Send(mailMessage);

            return Task.CompletedTask;
        }


        public Task SendEmailAsync(string email, string subject, string message) {

            return Task.CompletedTask;

        }
    }
}
