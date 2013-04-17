using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class AdminFaqController : Controller
    {
        private FaqService faq = new FaqService();
        //
        // GET: /AdminFaq/

        public ActionResult Index()
        {
            IEnumerable<Faq> data = faq.FindAll();
            return View(data);
        }

        //
        // GET: /AdminFaq/Details/5

        public ActionResult Details(int id)
        {
            Faq model = faq.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // GET: /AdminFaq/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminFaq/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Faq new_model = new Faq();
                    new_model.question = Request.Form["question"];
                    new_model.answer = Request.Form["answer"];
                    new_model.status = Convert.ToInt32(Request.Form["status"]);
                    new_model.sequence = Request.Form["sequence"];
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
        // GET: /AdminFaq/Edit/5
 
        public ActionResult Edit(int id)
        {
            Faq model = faq.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminFaq/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Faq model = faq.FindBy(id);
                    model.question = Request.Form["question"];
                    model.answer = Request.Form["answer"];
                    model.status = Convert.ToInt32(Request.Form["status"]);
                    model.sequence = Request.Form["sequence"];
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
        // GET: /AdminFaq/Delete/5
 
        public ActionResult Delete(int id)
        {
            Faq model = faq.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminFaq/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    Faq model = faq.FindBy(id);
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
