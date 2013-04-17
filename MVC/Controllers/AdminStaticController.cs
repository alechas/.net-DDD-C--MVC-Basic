using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

using System.Diagnostics;
using System.IO;

namespace PHD.MVC.Controllers
{
    public class AdminStaticController : Controller
    {
        //
        // GET: /Static/
        private StaticService Static = new StaticService();
        public ActionResult Index()
        {
            IEnumerable<Static> data = Static.FindAll();
            return View(data);
        }

        //
        // GET: /Static/Details/5

        public ActionResult Details(int id)
        {
            Static model = Static.FindBy(id);

            return View(model);
        }

        //
        // GET: /Static/Create

        public ActionResult Create()
        {
            Static model = new Static();
            return View(model);
        } 

        //
        // POST: /Static/Create

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase image)
        {
            Static model = new Static();
            TypestaticService serv_type = new TypestaticService();

            string path = "";
            string pathsave = "";

            try
            {
                if (image != null)
                {
                    if (image.ContentLength > 0)
                    {
                        DateTime _starttime = DateTime.UtcNow;
                        string fileName = _starttime.Ticks.ToString() + '_' + Path.GetFileName(image.FileName);


                        var file = Path.GetFullPath(Server.MapPath(@"~\Upload\static"));
                        if (!Directory.Exists(file))
                        {
                            Directory.CreateDirectory(file);
                        }

                        path = Path.Combine(file, fileName);
                        image.SaveAs(path);
                        pathsave = @"/Upload/static" + "/" + fileName;
                    }
                }

                model.name = Request.Form["name"];
                model.position = Convert.ToInt32(Request.Form["position"]);
                model.text = Request.Form["text"];
                model.url = pathsave;
                model.typestatic = serv_type.FindBy(Convert.ToInt32(Request.Form["type"]));
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
        // GET: /Static/Edit/5
 
        public ActionResult Edit(int id)
        {
            Static model = Static.FindBy(id);
            model.type = model.typestatic.Id;
            return View(model);
        }

        //
        // POST: /Static/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection,HttpPostedFileBase image)
        {
             TypestaticService serv_type = new TypestaticService();
             Static model = Static.FindBy(id);
             string path = "";
             String pathsave = "";

             try
             {

                 if (image != null)
                 {
                     if (image.ContentLength > 0)
                     {
                         DateTime _starttime = DateTime.UtcNow;
                         string fileName = _starttime.Ticks.ToString() + '_' + Path.GetFileName(image.FileName);


                         var file = Path.GetFullPath(Server.MapPath(@"~\Upload\static"));
                         if (!Directory.Exists(file))
                         {
                             Directory.CreateDirectory(file);
                         }

                         path = Path.Combine(file, fileName);
                         image.SaveAs(path);
                         pathsave = @"/Upload/static" + "/" + fileName;
                     }
                 }

                model.name = Request.Form["name"];
                model.position = Convert.ToInt32(Request.Form["position"]);
                model.text = Request.Form["text"];
                if(pathsave !="")
                {
                    model.url = pathsave;
                }
                model.typestatic = serv_type.FindBy(Convert.ToInt32(Request.Form["type"]));
                model.Save();
                // TODO: Add update logic here
 
                return RedirectToAction("Details/"+model.Id);
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Static/Delete/5
 
        public ActionResult Delete(int id)
        {
            Static model = Static.FindBy(id);
            return View(model);
        }

        //
        // POST: /Static/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
             Static model = Static.FindBy(id);
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
