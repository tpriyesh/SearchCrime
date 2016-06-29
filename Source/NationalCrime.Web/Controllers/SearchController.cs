using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NationalCrime.Web.NationalCrimeService;
using NationalCrime.Web.ViewModel;
using System.ServiceModel;

namespace NationalCrime.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            var model = new SearchViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                NationalCrimeServiceClient client = new NationalCrimeServiceClient();
                try
                {
                   int criminalCount= client.SearchCriminal(model.Name, model.Nationality, model.Gender, model.StartHeightRange, model.EndHeightRange, model.StartWeightRange, model.EndWeightRange, model.StartAge, model.EndAge, model.Email);
                   if (criminalCount == 0)
                   {
                       ViewData["success"] = criminalCount + " criminal found";
                  
                   }
                   else if (criminalCount == 1)
                   {
                       ViewData["success"] = criminalCount + " criminal  found.Criminal details is sent to the the mail.Please check the mail " + model.Email;
                   }
                   else
                   {
                       ViewData["success"] = criminalCount + " criminals are found.Criminals detail is sent to the the mail.Please check the mail " + model.Email;
                   }
                   return View(model);
                }
                catch (FaultException e)
                {
                    string messages = e.Message;
                    string[] errors = messages.Split(',');
                    ViewData["errors"] = errors;
                    return View(model);

                }
            }
            return View(model);
        }
    }
}
