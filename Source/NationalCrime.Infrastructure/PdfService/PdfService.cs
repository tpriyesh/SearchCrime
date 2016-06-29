using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCrime.Infrastructure.PdfService
{
   public class PdfService:IPdfService
    {
        public System.IO.MemoryStream PDFGenerate(Dal.criminal crime)
        {
            MemoryStream output = new MemoryStream();
            Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, output);
            pdfDoc.Open();

            Paragraph Text = new Paragraph("Name " + crime.name);
            pdfDoc.Add(Text);
            Paragraph Text1 = new Paragraph(
                "Age " + crime.age);
            pdfDoc.Add(Text1);
            Paragraph Text2 = new Paragraph("Nationality " + crime.nationality);
            pdfDoc.Add(Text2);

            Paragraph Text3 = new Paragraph("Height " + crime.height + " " + "CM");
            pdfDoc.Add(Text3);

            Paragraph Text4 = new Paragraph("Weight " + crime.weight + " " + "KG");
            pdfDoc.Add(Text4);

            Paragraph Text5 = new Paragraph("Gender " + crime.sex);
            pdfDoc.Add(Text5);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            output.Position = 0;

            return output;
        }
    }
}
