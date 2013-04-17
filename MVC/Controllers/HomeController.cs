using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using PHD.MVC.Models;
using PHD.MVC.Helper;
using PHD.Session.Classes;
using PHD.Service.ModelService;
using NHibernate.Criterion;
using System.Collections;
using System.Globalization;

namespace PHD.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Welcome to ASP.NET MVC!";
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Landing()
        {
            return View();
        }


        public ActionResult Notifikasi(int id)
        {
            switch(id)
            {
                case 1:
                    ViewBag.message = "Silahkan login terlebih dahulu";
                    break;
                case 2:
                    ViewBag.message = "Silahkan order terlebih dahulu";
                    break;
                case 3:
                    ViewBag.message = "Order tidak dapat diproses karena di luar jam Delivery";
                    break;
                case 4:
                    ViewBag.message = "Format Tanggal Salah";
                    break;
                case 5:
                    ViewBag.message = "Pembayaran dibawah limit yang ditentukan";
                    break;
                case 6:
                    ViewBag.message = "Outlet saat ini sedang tidak melayani Delivery";
                    break;
                case 7:
                    ViewBag.message = "Maaf menu yang anda pesan habis";
                    break;
                case 8:
                    ViewBag.message = "Maaf Uang Pembayaran yang anda masukkan kurang";
                    break;
            }
            return View();
        }


        public ActionResult RegisterOk()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                    UserService userv = new UserService();
                    //User new_model = userv.FindAllByCriteriaQuery();                                       
                    return RedirectToAction("Index");                
                    //return View();
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {

            return View();
        }

       
       
        public ActionResult Register()
        {
            User model = new User();
        

            ViewBag.message = ""; 
            return View(model);
        }
        
        
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            StringHelper help = new StringHelper();
            User model = new User();
            string temp = Request.Form["password"];
       
            ViewBag.message = "";
            try
            {
               
            }
            catch
            {
                model.password = temp;
                ViewBag.message = "Registrasi anda gagal<br>"+ViewBag.message;
                
            }
            return View(model);
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

       


   

    }
}
