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
            Static about = new StaticService().FindByCriteria(Crit);
         

            ViewBag.about = about;
            return View();
        }

        public ActionResult Outlet( int? page, string table = "id", string sort = "asc",int area = -1)
        {

            int total;
           
            List<ICriterion> Crit = new List<ICriterion>();
            IEnumerable<Area> data_area = new AreaService().FindAllByCriteria(Crit, out total, 0, 100, "id","ASC");
            ViewBag.data_area = data_area;

            int max = 6;
            int currentPageIndex = page.HasValue ? page.Value : 1;

            List<ICriterion> Crit2 = new List<ICriterion>();

            if (area != -1)
            {
                Crit2.Add(Restrictions.Eq("area.id", area));
            }
            IEnumerable<Outlet> outlets = new OutletService().FindAllByCriteria(Crit2, out total,(currentPageIndex - 1) * max, max, table, sort);
            ViewBag.outlets = outlets;

            ViewData["Current"] = currentPageIndex;
            ViewData["PageSize"] = max;
            ViewData["TotalCount"] = total;
            ViewBag.area = area;

           
            return View();
        }


        [HttpPost]
        public ActionResult Outlet(FormCollection collection,int? page, string table = "id", string sort = "asc")
        {

            int total;

            List<ICriterion> Crit = new List<ICriterion>();
            IEnumerable<Area> data_area = new AreaService().FindAllByCriteria(Crit, out total, 0, 100, "id", "ASC");
            ViewBag.data_area = data_area;

            int max = 6;
            int currentPageIndex = page.HasValue ? page.Value : 1;

            List<ICriterion> Crit2 = new List<ICriterion>();
            Crit2.Add(Restrictions.Eq("area.id",Convert.ToInt32(Request.Form["area"])));
            IEnumerable<Outlet> outlets = new OutletService().FindAllByCriteria(Crit2, out total, (currentPageIndex - 1) * max, max, table, sort);
            ViewBag.outlets = outlets;

            ViewData["Current"] = currentPageIndex;
            ViewData["PageSize"] = max;
            ViewData["TotalCount"] = total;
            ViewBag.area = Convert.ToInt32(Request.Form["area"]);
            return View();
        }

        public ActionResult Map(int id)
        {
            Outlet model = new OutletService().FindBy(id);
            ViewBag.outlet = model;
            return View();
        }

        public ActionResult Survey()
        {
            Saran model = new Saran();

            return View(model);
        }

        [HttpPost]
        public ActionResult Survey(FormCollection collection)
        {
            Saran model = new Saran();
            try
            {
                ViewBag.saran = model;
                if (!User.Identity.IsAuthenticated)// bkn user
                {
                    model.email = Request.Form["email"];
                    model.pesan = Request.Form["pesan"];
                    model.phone = Request.Form["phone"];
                    model.date = DateTime.Now;

                    model.Save();
                    return RedirectToAction("index");
                }
                else // user
                {
                    User user = new userHelper().GetUser(User.Identity.Name);
                    model.email = user.email;
                    model.pesan = Request.Form["pesan"];
                    model.phone = user.hp;
                    model.date = DateTime.Now;
                    model.user = user;

                    model.Save();
                    return  RedirectToAction("index");
                }
            }
            catch
            {
                return View(model);
            }
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
