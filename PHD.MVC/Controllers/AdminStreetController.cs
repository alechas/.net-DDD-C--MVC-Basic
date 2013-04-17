using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class AdminStreetController : Controller
    {
        private StreetService street = new StreetService(); 
        //
        // GET: /AdminStreet/

        public ActionResult Index()
        {
            IEnumerable<Street> data = street.FindAll();
            //ViewBag.data = data;
            return View(data);
        }

        //
        // GET: /AdminStreet/Details/5

        public ActionResult Details(int id)
        {
            Street model = street.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // GET: /AdminStreet/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminStreet/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Street new_model = new Street();
                    new_model.name = Request.Form["name"];
                    new_model.id_city = Convert.ToInt32(Request.Form["id_city"]);
                    new_model.id_outlet = Convert.ToInt32(Request.Form["id_outlet"]);
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
        // GET: /AdminStreet/Edit/5
 
        public ActionResult Edit(int id)
        {
            Street model = street.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminStreet/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Street model = street.FindBy(id);
                    model.name = Request.Form["name"];
                    model.id_city = Convert.ToInt32(Request.Form["id_city"]);
                    model.id_outlet = Convert.ToInt32(Request.Form["id_outlet"]);
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
        // GET: /AdminStreet/Delete/5
 
        public ActionResult Delete(int id)
        {
            Street model = street.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminStreet/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    Street model = street.FindBy(id);
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
