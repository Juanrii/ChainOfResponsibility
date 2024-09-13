using System;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace ChainOfResponsibility.Services.Email
{
    public class EmailSender
    {
        private static MailMessage _mail;
        private static SmtpClient _smtpClient;

        public static void RunMFA(string emailDestino, string codigo)
        {
            try
            {
                CrearMailMessage(emailDestino, codigo);

                CrearClienteSMTP();

                EnviarCorreo();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar el correo de verificación: " + ex.Message);
            }
        }

        private static void EnviarCorreo()
        {
            _smtpClient.Send(_mail);
        }

        private static void CrearClienteSMTP()
        {
            _smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            _smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]); 
            _smtpClient.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SmtpEmail"], 
                ConfigurationManager.AppSettings["SmtpPassword"]
            );
            _smtpClient.EnableSsl = true; 
        }

        private static void CrearMailMessage(string emailDestino, string codigo)
        {
            _mail = new MailMessage();

            _mail.From = new MailAddress(ConfigurationManager.AppSettings["SmtpEmail"]);
            _mail.To.Add(emailDestino);
            _mail.Subject = "Código de Verificación";
            _mail.Body = $"Tu código de verificación es: {codigo}";
        }
    }
}
