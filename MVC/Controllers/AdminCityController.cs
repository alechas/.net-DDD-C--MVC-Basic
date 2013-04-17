using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class AdminCityController : Controller
    {
        private CityService city = new CityService(); 
        //
        // GET: /AdminCity/

        public ActionResult Index()
        {
            IEnumerable<City> data = city.FindAll();
            //ViewBag.data = data;
            return View(data);
        }

        //
        // GET: /AdminCity/Details/5

        public ActionResult Details(int id)
        {
            City model = city.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // GET: /AdminCity/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminCity/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    City new_model = new City();
                    new_model.name = Request.Form["name"];
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
        // GET: /AdminCity/Edit/5
 
        public ActionResult Edit(int id)
        {
            City model = city.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminCity/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    City model = city.FindBy(id);
                    model.name = Request.Form["name"];
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
        // GET: /AdminCity/Delete/5
 
        public ActionResult Delete(int id)
        {
            City model = city.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminCity/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    City model = city.FindBy(id);
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
