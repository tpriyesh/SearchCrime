using NationalCrime.Dal;
using NationalCrime.Infrastructure.MailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCrime.Infrastructure.TaskService
{
  public class TaskService:ITaskService
    {
        private List<criminal> _criminals = null;
        private string _email = "";
        private IMailService _mailService = null;
        public TaskService(IMailService mailService,string email,List<criminal> criminals)
        {
            this._email = email;
            this._criminals = criminals;
            this._mailService = mailService;
      
        }
       public void DoTask()
        {
            _mailService.SendMail(_email, _criminals);
        }
    }
}
