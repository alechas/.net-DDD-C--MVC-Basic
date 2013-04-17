using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using PHD.MVC.Models;
using PHD.MVC.Helper;
using PHD.Session.Classes;
using PHD.Service.ModelService;
using NHibernate.Criterion;
using System.Collections;
namespace PHD.MVC.Controllers
{
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                List<ICriterion> Crit = new List<ICriterion>();
                Crit.Add(Restrictions.Eq("email", model.UserName));
                Crit.Add(Restrictions.Eq("status", 1));
                Crit.Add(Restrictions.Eq("role.id", 3));
                User user = new UserService().FindByCriteria(Crit);


                string username;
                if(user!=null)
                {
                    username = user.email;
                }
                else
                {
                    username = model.UserName;
                }

                if (MembershipService.ValidateUser(username, model.Password))
                {
                    FormsService.SignIn(username, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        if (user.role.name != "admin")
                            return RedirectToAction("selectaddress", "Home");
                        else
                            return RedirectToAction("Index", "AdminUser");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }


        public ActionResult Autocompleteaddress(string term)
        {
            ArrayList arraylist = new ArrayList();
           
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("name", term));
            int total;
            IEnumerable<Street> streets = new StreetService().FindAllByCriteria(Crit,out total,0,10,"id","asc");

            foreach (var row in streets)
            {
                arraylist.Add(row.name);
            }
            var filteredItems = arraylist.ToArray();
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }
    }
}
