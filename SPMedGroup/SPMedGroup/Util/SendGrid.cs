using SendGrid;
using SendGrid.Helpers.Mail;
using SPMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.Util
{
    public class SendGrid
    {
        static string email { get; set; }

        static async Task Execute()
        {
            //Informe sua ApiKey do SendGrid
            var client = new SendGridClient("");
            var from = new EmailAddress("matheushpribeiro@hotmail.com", "SP Med Group");
            var subject = "SP Medical Group Consultas";
            var to = new EmailAddress(email, "Paciente");
            var plainTextContent = "Consulta";
            var htmlContent = "<strong>Consulta na clínica SPMedGroup marcada";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public void Enviar(string emailRecebido)
        {
            email = emailRecebido;

            Execute().Wait();
        }
    }
}
