using NationalCrime.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NationalCrime.Web.NationalCrimeService;
using System.Globalization;
using System.Web.Security;
using System.ServiceModel;

namespace NationalCrime.Web.Controllers
{
    public class AccountController : Controller
    {
        NationalCrimeServiceClient client = new NationalCrimeServiceClient();
        
        public ActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("Search");
            }
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (client.ValidateLogin(model.UserName, model.Password))
                {
                    SetupFormsAuthTicket(model.UserName, false);
                    return RedirectToRoute("Search");
                }
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("Search");
            }
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                  string status=  client.Register(model.UserName, model.Email, model.Password);
                  if (status == "DuplicateEmail")
                  {
                      ModelState.AddModelError("", "Email is Duplicated");
                  }
                  else if (status == "DuplicateUserName")
                  {
                      ModelState.AddModelError("", "UserName is Duplicate");
                  }
                  else if (status == "Success")
                  {
                      ViewData["success"] = "Account is created.Now go to login screen to login";
                      model.Email = "";
                      model.Password = "";
                      model.UserName = "";
                      model.ConfirmPassword = "";
                  }
                }
                catch (FaultException e)
                { 
                
                }
               
            }
            return View(model);
           
        }

        private void SetupFormsAuthTicket(string userName, bool persistanceFlag)
        {
            
            var userData = userName;
            var authTicket = new FormsAuthenticationTicket(1, //version
                                                        userName, // user name
                                                        DateTime.Now,             //creation
                                                        DateTime.Now.AddMinutes(30), //Expiration
                                                        persistanceFlag, //Persistent
                                                        userData);

            var encTicket = FormsAuthentication.Encrypt(authTicket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
           
        }


    }
}
