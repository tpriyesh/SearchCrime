using NationalCrime.Dal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCrime.Infrastructure.PdfService
{
    public interface IPdfService
    {
        MemoryStream PDFGenerate(criminal crime);
    }
}
