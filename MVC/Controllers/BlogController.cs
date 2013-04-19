using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.ModelService;
using Session.Classes;
using MVC.Helper;
using NHibernate.Criterion;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Collections;

namespace MVC.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        private BlogService blogserv = new BlogService();

        public ActionResult Index(int? page, string header = "", string text = "")
        {
            int Total;
            int max = 10;
            int currentPageIndex = page.HasValue ? page.Value : 1;

            List<ICriterion> Criterion = new List<ICriterion>();

            if (header != "")
            {
                Criterion.Add(Restrictions.Like("header", "%"+header+"%"));
            }
            if (text != "")
            {
                Criterion.Add(Restrictions.Like("text", "%" + text + "%"));
            }

            IEnumerable<Blog> data = blogserv.FindAllByCriteria(Criterion, out Total,(currentPageIndex - 1) * max, max, "Id", "Desc") ;
          
            ViewData["Current"] = currentPageIndex;
            ViewData["PageSize"] = max;
            ViewData["TotalCount"] = Total;
            return View(data);
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Blog/Create

        public ActionResult Create()
        {
            Blog model = new Blog();
            return View(model);
        } 

        //
        // POST: /Blog/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Blog model = new Blog(); 

            try
            {
                model.header = collection["header"];
                model.text = collection["text"];
                model.createdBy = new userHelper().GetUser(User.Identity.Name);
                model.created = DateTime.Now;
                model.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        
        //
        // GET: /Blog/Edit/5
 
        public ActionResult Edit(int id)
        {
            Blog model = blogserv.FindBy(id);

            return View(model);
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Blog model = blogserv.FindBy(id);
            try
            {
                model.header = collection["header"];
                model.text = collection["text"];
                model.Save();
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Blog/Delete/5
 
        public ActionResult Delete(int id)
        {
            Blog model = blogserv.FindBy(id);
            return View(model);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Blog model = blogserv.FindBy(id);
            try
            {
                model.Delete();
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
