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

        public void Execute(string email)
        {
            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("matheushpribeiro@hotmail.com", "SP Med Group"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                PlainTextContent = "Hello, Email!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };

            msg.AddTo(new EmailAddress(email, "Test User"));
            var response = client.SendEmailAsync(msg);
        }
    }
}
