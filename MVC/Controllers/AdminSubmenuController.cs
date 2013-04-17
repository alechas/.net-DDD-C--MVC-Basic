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
    public class AdminSubmenuController : Controller
    {
        //
        // GET: /AdminSubmenu/
        private SubmenuService Submenu = new SubmenuService();
        public ActionResult Index()
        {
            IEnumerable<Submenu> data = Submenu.FindAll();

            return View(data);
        }

        //
        // GET: /AdminSubmenu/Details/5

        public ActionResult Details(int id)
        {
            Submenu model = Submenu.FindBy(id);
            return View(model);
        }

        //
        // GET: /AdminSubmenu/Create

        public ActionResult Create()
        {
            Submenu model = new Submenu();
            return View(model);
        } 

        //
        // POST: /AdminSubmenu/Create

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase image)
        {
            Submenu model = new Submenu();
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


                        var file = Path.GetFullPath(Server.MapPath(@"~\Upload\submenu"));
                        if (!Directory.Exists(file))
                        {
                            Directory.CreateDirectory(file);
                        }

                        path = Path.Combine(file, fileName);
                        image.SaveAs(path);
                        pathsave = @"/Upload/submenu" + "/" + fileName;
                    }
                }

                model.name = Request.Form["name"];
                model.kode = Request.Form["kode"];
                model.price = float.Parse(Request.Form["price"]);
                model.image = pathsave;
                model.id_menu = Int32.Parse(Request.Form["id_menu"]);
                model.id_submenu = Int32.Parse(Request.Form["id_submenu"]);
                model.status = Int32.Parse(Request.Form["status"]);
                model.text = Request.Form["text"];
                model.description = Request.Form["description"];
                model.Save();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        
        //
        // GET: /AdminSubmenu/Edit/5
 
        public ActionResult Edit(int id)
        {
            Submenu model = Submenu.FindBy(id);
            return View(model);
        }

        //
        // POST: /AdminSubmenu/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,HttpPostedFileBase image)
        {
            Submenu model = Submenu.FindBy(id);
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


                        var file = Path.GetFullPath(Server.MapPath(@"~\Upload\submenu"));
                        if (!Directory.Exists(file))
                        {
                            Directory.CreateDirectory(file);
                        }

                        path = Path.Combine(file, fileName);
                        image.SaveAs(path);
                        pathsave = @"/Upload/submenu" + "/" + fileName;
                    }
                }

                model.name = Request.Form["name"];
                model.kode = Request.Form["kode"];
                model.price = float.Parse(Request.Form["price"]);

                if (pathsave != "")
                {
                    model.image = pathsave;
                }

                model.id_menu = Int32.Parse(Request.Form["id_menu"]);
                model.id_submenu = Int32.Parse(Request.Form["id_submenu"]);
                model.status = Int32.Parse(Request.Form["status"]);
                model.text = Request.Form["text"];
                model.description = Request.Form["description"];
                model.Save();
                // TODO: Add insert log
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /AdminSubmenu/Delete/5
 
        public ActionResult Delete(int id)
        {
            Submenu model = Submenu.FindBy(id);

            return View();
        }

        //
        // POST: /AdminSubmenu/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Submenu model = Submenu.FindBy(id);

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
