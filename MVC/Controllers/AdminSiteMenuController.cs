using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class AdminSiteMenuController : Controller
    {
        private SitemenuService sitemenu = new SitemenuService(); 
        //
        // GET: /AdminSiteMenu/

        public ActionResult Index()
        {
            IEnumerable<Sitemenu> data = sitemenu.FindAll();
            //ViewBag.data = data;
            return View(data);
        }

        //
        // GET: /AdminSiteMenu/Details/5

        public ActionResult Details(int id)
        {
            Sitemenu model = sitemenu.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // GET: /AdminSiteMenu/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminSiteMenu/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Sitemenu new_model = new Sitemenu();
                    new_model.name = Request.Form["name"];
                    new_model.position = Convert.ToInt32(Request.Form["position"]);
                    new_model.url = Request.Form["url"];
                    new_model.image = Request.Form["image"];
                    new_model.type = Convert.ToInt32(Request.Form["type"]);
                    new_model.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /AdminSiteMenu/Edit/5
 
        public ActionResult Edit(int id)
        {
            Sitemenu model = sitemenu.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminSiteMenu/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Sitemenu model = sitemenu.FindBy(id);
                    model.name = Request.Form["name"];
                    model.position = Convert.ToInt32(Request.Form["position"]);
                    model.url = Request.Form["url"];
                    model.image = Request.Form["image"];
                    model.type = Convert.ToInt32(Request.Form["type"]);
                    model.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminSiteMenu/Delete/5
 
        public ActionResult Delete(int id)
        {
            Sitemenu model = sitemenu.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminSiteMenu/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    Sitemenu model = sitemenu.FindBy(id);
                    model.Delete();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
