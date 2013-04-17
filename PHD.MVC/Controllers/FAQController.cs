using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;
using NHibernate.Criterion;
namespace PHD.MVC.Controllers
{
    public class FAQController : Controller
    {
        //
        // GET: /FAQ/
        public static FaqService faqserv = new FaqService();
        public ActionResult Index()
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("status", 1));
            int total;

            IEnumerable < Faq > data = faqserv.FindAllByCriteria(Crit, out total, 0, 100, "sequence", "ASC");

            ViewBag.data = data;
            return View();
        }

    }
}
