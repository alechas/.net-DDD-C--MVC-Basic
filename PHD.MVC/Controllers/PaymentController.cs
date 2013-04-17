using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Criterion;
using PHD.Service.ModelService;
using PHD.Session.Classes;
using PHD.MVC.Helper;
namespace PHD.MVC.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        public ActionResult Index()
        {
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("typestatic.id", 3));
            Static payment = new StaticService().FindByCriteria(Crit);


            ViewBag.payment = payment;
            return View();
        }

        public ActionResult Kompas(int id, string a)
        {

            return View();
        }

    }
}
