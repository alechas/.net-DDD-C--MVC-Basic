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
    public class TrackOrderController : Controller
    {
        //
        // GET: /TrackOrder/

        public ActionResult Index(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("logon", "account");
            }
            Ordercust order = new Ordercust();
            int idorder = 0;
            if (id.HasValue)
            {
                idorder = id.Value;
            }
            if (idorder != 0)
            {
                order = new OrdercustService().FindBy(idorder);

            }
            else
            {
                List<ICriterion> Crit = new List<ICriterion>();
                User current = new userHelper().GetUser(User.Identity.Name);
                Crit.Add(Restrictions.Eq("user.id", current.Id));
                Crit.Add(Restrictions.Gt("status.id", 1));
                int total;
                IEnumerable<Ordercust> orders = new OrdercustService().FindAllByCriteria(Crit,out total,0,100,"created","DESC");
                if (orders == null || orders.Count() == 0)
                {
                    return RedirectToAction("empty");
                }
                else { order = orders.ElementAt<Ordercust>(0); }
            } 
            ViewBag.order = order;
            return View();
        }

        public ActionResult Empty(int? id)
        {
            
            return View();
        }
    }


}
