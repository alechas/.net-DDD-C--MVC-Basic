using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class AdminOutletController : Controller
    {


        private OutletService outlet = new OutletService();
        //
        // GET: /AdminOutlet/

        public ActionResult Index()
        {
            IEnumerable<Outlet> data = outlet.FindAll();
            ViewBag.data = data;
            return View(data);
        }

        //
        // GET: /AdminOutlet/Details/5

        public ActionResult Details(int id)
        {
            Outlet model = outlet.FindBy(id);
            return View(model);
        }

        //
        // GET: /AdminOutlet/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminOutlet/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Outlet model = new Outlet();
            try
            {
                model.kode = Request.Form["kode"];
                model.description = Request.Form["description"];
                model.name = Request.Form["name"];
                model.Save();

                // TODO: Add insert logic here

                return RedirectToAction("Details/"+model.Id);
            }
            catch
            {
                return View(model);
            }
        }
        
        //
        // GET: /AdminOutlet/Edit/5
 
        public ActionResult Edit(int id)
        {
            Outlet model = outlet.FindBy(id);
            return View(model);
        }

        //
        // POST: /AdminOutlet/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Outlet model = outlet.FindBy(id);
            try
            {
                model.kode = Request.Form["kode"];
                model.description = Request.Form["description"];
                model.name = Request.Form["name"];
                model.Save();
 
                return RedirectToAction("Details/"+model.Id);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminOutlet/Delete/5
 
        public ActionResult Delete(int id)
        {
            Outlet model = outlet.FindBy(id);

            return View(model);
        }

        //
        // POST: /AdminOutlet/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Outlet model = outlet.FindBy(id);

            try
            {
                // TODO: Add delete logic here
                model.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
