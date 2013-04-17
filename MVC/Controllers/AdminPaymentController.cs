using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class AdminPaymentController : Controller
    {
        private PaymentService payment = new PaymentService();
        //
        // GET: /AdminPayment/

        public ActionResult Index()
        {
            IEnumerable<Payment> data = payment.FindAll();
            //ViewBag.data = data;
            return View(data);
        }

        //
        // GET: /AdminPayment/Details/5

        public ActionResult Details(int id)
        {
            Payment model = payment.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // GET: /AdminPayment/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminPayment/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Payment new_model = new Payment();
                    new_model.name = Request.Form["name"];
                    new_model.description = Request.Form["description"];
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
        // GET: /AdminPayment/Edit/5
 
        public ActionResult Edit(int id)
        {
            Payment model = payment.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminPayment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Payment model = payment.FindBy(id);
                    model.name = Request.Form["name"];
                    model.description = Request.Form["description"];
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
        // GET: /AdminPayment/Delete/5
 
        public ActionResult Delete(int id)
        {
            Payment model = payment.FindBy(id);
            //ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminPayment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    Payment model = payment.FindBy(id);
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
