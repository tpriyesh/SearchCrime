using NationalCrime.Dal;
using NationalCrime.Infrastructure.PdfService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NationalCrime.Infrastructure.MailService
{
   public class MailService:IMailService
    {
       private IPdfService _pdfService = null;
       private string _email = "";
       private List<criminal> _criminals = null;
       public MailService(IPdfService pdfService,string email,List<criminal> criminals)
       {
           _pdfService = pdfService;
           _criminals = criminals;
           _email = email;
           
       }
        public void SendMail(string email, List<Dal.criminal> criminals)
        {
            MailMessage message = new MailMessage();
            message.To.Add(email);// Email-ID of Receiver  
            message.Subject = "Criminal Records";// Subject of Email  
            message.From = new System.Net.Mail.MailAddress("no-reply@test.com");// Email-ID of Sender  
            message.IsBodyHtml = true;
            AddAsAttachments(message.Attachments, criminals, email);
            message.Body = "Crime Report";
            using (SmtpClient SmtpMail = new SmtpClient())
            {
                SmtpMail.Host = Convert.ToString(ConfigurationManager.AppSettings["Host"]);//name or IP-Address of Host used for SMTP transactions  
                SmtpMail.Port = Convert.ToInt16(ConfigurationManager.AppSettings["Port"]);//Port for sending the mail  
                SmtpMail.Credentials = new System.Net.NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["UserName"]), Convert.ToString(ConfigurationManager.AppSettings["Password"]));//username/password of network, if apply  
                SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpMail.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                SmtpMail.ServicePoint.MaxIdleTime = 0;
                SmtpMail.ServicePoint.SetTcpKeepAlive(true, 2000, 2000);
                message.BodyEncoding = Encoding.Default;
                message.Priority = MailPriority.High;
                SmtpMail.Send(message); //Smtpclient to send the mail message  
            }
        }

        private void AddAsAttachments(AttachmentCollection attachmentCollection, List<criminal> criminals, string email)
        {
            var criminalCount = 0;

            foreach (var criminal in criminals)
            {
                if (criminalCount == 10)
                {
                    return;
                }

                var file = new MemoryStream(_pdfService.PDFGenerate(criminal).ToArray());
                file.Seek(0, SeekOrigin.Begin);
                Attachment data = new Attachment(file, criminal.name + criminal.id + ".pdf", "application/pdf");
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.DateTime.Now;
                disposition.ModificationDate = System.DateTime.Now;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                attachmentCollection.Add(data);//Attach the file  
                criminalCount++;
                if (criminalCount == 10 && criminals.Count > 10)
                {
                    var remainingRecord = criminals.Count - criminalCount;
                    var subList = criminals.Skip(criminalCount).Take(remainingRecord).ToList();
                    SendMail(email, subList);
                }


            }
        }
    }
}
