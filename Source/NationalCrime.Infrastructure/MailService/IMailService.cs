using NationalCrime.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCrime.Infrastructure.MailService
{
   public interface IMailService
    {
        void SendMail(string email, List<criminal> criminals);
    }
}
