using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ISG.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Enviar(string name, string email, string subject,string message)
        {
            try
            {
                MailMessage mail = new MailMessage("sistemas@inflor.com.br", "contato@isgconsultoria.com.br");
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "mail.inflor.com.br";
                NetworkCredential credentials = new NetworkCredential("sistemas@inflor.local", "sysinflor");
                client.Credentials = credentials;
                mail.Subject = "Email do Site ISG";
                mail.Body = "Nome: \r\n" + name + "\r\n\r\nAssunto: \r\n" + subject + "\r\n\r\nMenssagem: \r\n" + message + "\r\n" + "\r\n\r\nContato: \r\n" + email;
                client.Send(mail);

                return "E-mail enviado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Tente novamente!";
            }
        }

    }
}
