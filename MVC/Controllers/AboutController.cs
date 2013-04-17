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
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Index()
        {
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("typestatic.id", 1));
        
    
            return View();
        }

        public ActionResult Outlet( int? page, string table = "id", string sort = "asc",int area = -1)
        {

            int total;
           
            List<ICriterion> Crit = new List<ICriterion>();
       


            int max = 6;
            int currentPageIndex = page.HasValue ? page.Value : 1;

            List<ICriterion> Crit2 = new List<ICriterion>();

            if (area != -1)
            {
                Crit2.Add(Restrictions.Eq("area.id", area));
            }

            ViewData["Current"] = currentPageIndex;
            ViewData["PageSize"] = max;
            ViewBag.area = area;
            return View();
        }

      
        public ActionResult Career()
        {
            return View();
        }

        public ActionResult QuickApply()
        {
            return View();
        }

    }
}
