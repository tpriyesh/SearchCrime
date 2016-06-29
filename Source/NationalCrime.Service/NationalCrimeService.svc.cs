using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NationalCrime.Dal;
using System.Threading;
using NationalCrime.Infrastructure;
using NationalCrime.Infrastructure.MailService;
using NationalCrime.Infrastructure.PdfService;
using NationalCrime.Infrastructure.TaskService;
using NationalCrime.Service.Infrastructure;
using System.Web.Security;

namespace NationalCrime.Service
{
     public class Service1 : DefaultDisposable, INationalCrimeService
    {
        IMembershipService _membershipService = new AccountMembershipService();
        public bool ValidateLogin(string username, string password)
        {
            return _membershipService.ValidateUser(username, password);
        }

        public string Register(string username,string email,string password)
        {
            var status=_membershipService.CreateUser(username, password, email);
            var returnStatus= status.ToString();
            return returnStatus;
        }

        public int SearchCriminal(string name, string nationality, string gender, float startheight, float endheight, float startweight, float endweight, int startage, int endage,string email)
        {
            var errors=ValidateParameters(startheight, endheight, startweight, endweight, startage, endage,email);
            if (errors.Count > 0)
            { 
            var result = string.Join(",", errors.ToArray());
            throw new FaultException(result);
            }
            List<criminal> criminals = new List<criminal>();
            criminals = context.criminals.ToList<criminal>();
            if (!string.IsNullOrEmpty(gender))
            {
                criminals = criminals.Where(x => x.sex == gender).ToList<criminal>();
            }
            if (!string.IsNullOrEmpty(nationality))
            {
            criminals= criminals.Where(x => x.nationality == nationality).ToList<criminal>();
            }
            if (!string.IsNullOrEmpty(name))
            {
            criminals = criminals.Where(x =>x.name.Contains(name)).ToList<criminal>();
            }
            if (startheight != 0)
            {
              criminals=  criminals.Where(x => x.height >= startheight && x.height <= endheight).ToList<criminal>();
            }
            if (startage != 0)
            {
                criminals = criminals.Where(x => x.age >= startage && x.age <= endage).ToList<criminal>();
            }
            if (startweight != 0)
            {
                criminals = criminals.Where(x => x.weight >= startweight && x.weight <= endweight).ToList<criminal>();
            }
           
            if (criminals.Count > 0)
            {
                RunTaskInBackground(criminals, email);
            }
            return criminals.Count;
        }

        private void RunTaskInBackground(List<criminal> criminals,string email)
        {
            IPdfService pdfService = new PdfService();
            IMailService mailService = new MailService(pdfService,email,criminals);
            ITaskService taskService = new TaskService(mailService,email,criminals);

            //TaskManager manager = new TaskManager(criminals, email);
            Thread thread = new Thread(new ThreadStart(taskService.DoTask));
            thread.IsBackground = true;
            thread.Start();
        }

        private List<string> ValidateParameters(float startheight, float endheight, float startweight, float endweight, int startage, int endage,string email)
        {
            List<string> errors = new List<string>();
            if (startheight != 0)
            {
                if (startheight > endheight)
                {
                    errors.Add("End height should be more than start height");
                }
            }

            if (startweight != 0)
            {
                if (startweight > endweight)
                {
                    errors.Add("End weight should be more than start weight");
                }
            }

            if (startage != 0)
            {
                if (startage > endage)
                {
                    errors.Add("End age should be more than start age");
                }
            }

            if (string.IsNullOrEmpty(email))
            {
                errors.Add("email should be there");
            }

            return errors;
        }
    }
}
