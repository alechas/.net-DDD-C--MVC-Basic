using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class AdminMenuController : Controller
    {
        private MenuService menu = new MenuService();
        //
        // GET: /AdminMenu/

        public ActionResult Index()
        {
            IEnumerable<Menu> data = menu.FindAll();
            //ViewBag.data = data;
            return View(data);
        }

        //
        // GET: /AdminMenu/Details/5

        public ActionResult Details(int id)
        {
            Menu model = menu.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // GET: /AdminMenu/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminMenu/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Menu new_model = new Menu();
                    new_model.nama = Request.Form["nama"];
                    new_model.description = Request.Form["description"];
                    new_model.sequence = Convert.ToInt32(Request.Form["sequence"]);
                    new_model.title = Request.Form["title"];
                    new_model.status = Convert.ToInt32(Request.Form["status"]);
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
        // GET: /AdminMenu/Edit/5
 
        public ActionResult Edit(int id)
        {
            Menu model = menu.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminMenu/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Menu model = menu.FindBy(id);
                    model.nama = Request.Form["nama"];
                    model.description = Request.Form["description"];
                    model.sequence = Convert.ToInt32(Request.Form["sequence"]);
                    model.title = Request.Form["title"];
                    model.status = Convert.ToInt32(Request.Form["status"]);
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
        // GET: /AdminMenu/Delete/5
 
        public ActionResult Delete(int id)
        {
            Menu model = menu.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminMenu/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    Menu model = menu.FindBy(id);
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
