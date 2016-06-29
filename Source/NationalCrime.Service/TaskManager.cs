using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalCrime.Dal;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace NationalCrime.Service
{
    public class TaskManager
    {
        private List<criminal> listCriminals = null;
        private string email = "";
        public TaskManager(List<criminal> criminals,string email)
        {
            this.listCriminals = criminals;
            this.email = email;
        }
        public void DoTask()
        {
            SendMail(this.email, this.listCriminals);
        }

        
        private MemoryStream PDFGenerate(criminal crime)
        {
            MemoryStream output = new MemoryStream();
            Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, output);
            pdfDoc.Open();
            
            Paragraph Text = new Paragraph("Name "+crime.name);
            pdfDoc.Add(Text);
            Paragraph Text1 = new Paragraph(
                "Age "+crime.age);
            pdfDoc.Add(Text1);
            Paragraph Text2 = new Paragraph("Nationality "+crime.nationality);
            pdfDoc.Add(Text2);

            Paragraph Text3 = new Paragraph("Height " + crime.height+" "+"CM");
            pdfDoc.Add(Text3);

            Paragraph Text4 = new Paragraph("Weight " + crime.weight+" "+"KG");
            pdfDoc.Add(Text4);

            Paragraph Text5 = new Paragraph("Gender " + crime.sex);
            pdfDoc.Add(Text5);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            output.Position = 0;

            return output;
        }     

        private void SendMail(string email, List<criminal> criminals)
        {
            MailMessage message = new MailMessage();
            message.To.Add(email);// Email-ID of Receiver  
            message.Subject = "Criminal Records";// Subject of Email  
            message.From = new System.Net.Mail.MailAddress("no-reply@test.com");// Email-ID of Sender  
            message.IsBodyHtml = true;
            AddAsAttachments(message.Attachments, criminals,email);
            message.Body = "Crime Report";
            SmtpClient SmtpMail = new SmtpClient();
            SmtpMail.Host = "smtpout.secureserver.net";//name or IP-Address of Host used for SMTP transactions  
            SmtpMail.Port = 25;//Port for sending the mail  
            SmtpMail.Credentials = new System.Net.NetworkCredential("support@beeptool.com", "beeptool");//username/password of network, if apply  
            SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpMail.EnableSsl = false;
            SmtpMail.ServicePoint.MaxIdleTime = 0;
            SmtpMail.ServicePoint.SetTcpKeepAlive(true, 2000, 2000);
            message.BodyEncoding = Encoding.Default;
            message.Priority = MailPriority.High;
            SmtpMail.Send(message); //Smtpclient to send the mail message  
           
        }

        private void AddAsAttachments(AttachmentCollection attachmentCollection, List<criminal> criminals,string email)
        {
            var criminalCount = 0;
          
            foreach (var criminal in criminals)
            {
                if (criminalCount == 10)
                {
                    return;
                }
                
                var file = new MemoryStream(PDFGenerate(criminal).ToArray());
                    file.Seek(0, SeekOrigin.Begin);
                    Attachment data = new Attachment(file, criminal.name + criminal.id + ".pdf", "application/pdf");
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.DateTime.Now;
                    disposition.ModificationDate = System.DateTime.Now;
                    disposition.DispositionType = DispositionTypeNames.Attachment;
                    attachmentCollection.Add(data);//Attach the file  
                    criminalCount++;
                    if (criminalCount == 10&&criminals.Count>10)
                    {
                      var remainingRecord = criminals.Count - criminalCount;
                      var subList = criminals.Skip(criminalCount).Take(remainingRecord).ToList();
                      SendMail(email, subList);
                    }

            
            }
        }
    }
}