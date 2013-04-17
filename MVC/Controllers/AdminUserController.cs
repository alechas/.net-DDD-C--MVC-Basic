using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;
using PHD.MVC.Helper;
using NHibernate.Criterion;
using System.Diagnostics;
using System.IO;



namespace PHD.MVC.Controllers
{
    public class AdminUserController : Controller
    {

        private UserService user = new UserService();
        //
        // GET: /AdminUser/

        public ActionResult Index(int? page, string table = "username", string sort = "desc")
        {
       
            int Total;

            int max = 10;
            int currentPageIndex = page.HasValue ? page.Value : 1;

            List<ICriterion> Criterion = new List<ICriterion>();
           IEnumerable<User> data = user.FindAllByCriteria(Criterion, out Total,(currentPageIndex - 1) * max, max, table, sort) ;
            ViewBag.data = data;
            ViewData["Current"] = currentPageIndex;
            ViewData["PageSize"] = max;
            ViewData["TotalCount"] = Total;
            return View();
        }

        //
        // GET: /AdminUser/Details/5

        public ActionResult Details(int id)
        {
            
            User model = user.FindBy(id);
            ViewBag.model = model;
            return View(model);
        }

        //
        // GET: /AdminUser/Create

        public ActionResult Create()
        {
         
            User model = new User();
            return View(model);
        } 

        //
        // POST: /AdminUser/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase profile)
        {
            User model = new User();
            string path = "";
            string pathsave = "";
            try
            {
                if (profile != null && Request.Form["username"] != null)
                {
                    if (profile.ContentLength > 0)
                    {
                        DateTime _starttime = DateTime.UtcNow;
                        string fileName = _starttime.Ticks.ToString()+'_'+Path.GetFileName(profile.FileName);
                       

                        var file = Path.GetFullPath(Server.MapPath(@"~\Upload\" + Request.Form["username"]));
                        if (!Directory.Exists(file))
                        {
                            Directory.CreateDirectory(file);
                        }

                        path = Path.Combine(file, fileName);
                        profile.SaveAs(path);
                        pathsave = @"/Upload/" + Request.Form["username"] +"/" + fileName;
                    }
                }

                RoleService serv_role = new RoleService();
                model.username = Request.Form["username"];
                string temp = Request.Form["password"];
                if (pathsave != "")
                {
                    model.profpic = pathsave;
                }
                model.password = new md5helper().CalculateMD5Hash(Request.Form["password"]);
                model.nama = Request.Form["nama"];
                model.alamat = Request.Form["alamat"];
                model.hp = Request.Form["hp"];
                model.telepon = Request.Form["telepon"];
                model.kota = Request.Form["kota"];
                model.email = Request.Form["email"];
                model.provinsi = Request.Form["provinsi"];
                model.kode_pos = Request.Form["kode_pos"];
                model.role = serv_role.FindBy(Convert.ToInt32(Request.Form["id_role"]));
                model.status = Convert.ToInt32(Request.Form["status"]);
                model.Save();
                model.password = temp;
                // TODO: Add insert logic here
                return RedirectToAction("Details/"+model.Id);
               // return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        
        //
        // GET: /AdminUser/Edit/5
 
        public ActionResult Edit(int id)
        {
            User model = user.FindBy(id);
            model.id_role = model.role.Id;
            ViewBag.model = model;
            return View(model);
        }

        //
        // POST: /AdminUser/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase profile)
        {
            User model = user.FindBy(id);
            string path = "";
            string pathsave = "";

            try
            {

                RoleService serv_role = new RoleService();
                if (profile != null && Request.Form["username"] != null)
                {
                    if (profile.ContentLength > 0)
                    {
                        DateTime _starttime = DateTime.UtcNow;
                        string fileName = _starttime.Ticks.ToString() + '_' + Path.GetFileName(profile.FileName);


                        var file = Path.GetFullPath(Server.MapPath(@"~\Upload\" + Request.Form["username"]));
                        if (!Directory.Exists(file))
                        {
                            Directory.CreateDirectory(file);
                        }

                        path = Path.Combine(file, fileName);
                        profile.SaveAs(path);
                        pathsave = @"/Upload/" + Request.Form["username"] + "/" + fileName;
                    }
                }

                model.username = Request.Form["username"];
                string temp = Request.Form["password"];
                if (Request.Form["temp"] != model.password)
                {
                    model.password = new md5helper().CalculateMD5Hash(Request.Form["password"]);
                }
                model.profpic = pathsave;
                model.nama = Request.Form["nama"];
                if (pathsave != "")
                {
                    model.profpic = pathsave;
                }
                model.alamat = Request.Form["alamat"];
                model.hp = Request.Form["hp"];
                model.telepon = Request.Form["telepon"];
                model.kota = Request.Form["kota"];
                model.email = Request.Form["email"];
                model.provinsi = Request.Form["provinsi"];
                model.kode_pos = Request.Form["kode_pos"];
                model.role = serv_role.FindBy(Convert.ToInt32(Request.Form["id_role"]));
                model.status = Convert.ToInt32(Request.Form["status"]);
                model.Save();
                model.password = temp;
                // TODO: Add update logic here

                return RedirectToAction("Details/"+model.Id);

            }
            catch
            {
                 
                return View(model);
            }
        }

        //
        // GET: /AdminUser/Delete/5
 
        public ActionResult Delete(int id)
        {
            User model = user.FindBy(id);
            return View(model);
        }

        //
        // POST: /AdminUser/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            User model = user.FindBy(id);
            try
            {
                // TODO: Add delete logic here
              
                model.Delete();
                return RedirectToAction("Index");

            }
            catch
            {
                return View(model);
            }
        }
    }
}
