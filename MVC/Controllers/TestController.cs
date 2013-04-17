using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Controllers
{
    public class TestController : Controller
    {
        //private CommentService comment = new CommentService();
        private RoleService role = new RoleService();
        //
        // GET: /Test/

        public ActionResult Index()
        {
             RoleService _role = new RoleService();
       //    IEnumerable<Comment> datas = comment.FindAll();
            User usersave = new User();
            usersave.nama = "ivan";
            usersave.password = "abc";
            usersave.username = "ivan123";
            usersave.email = "ivan@wirekom.co.id";
            usersave.hp = "0857";
            usersave.telepon = "0857";
            usersave.status = 1;
            Role x = null;
            usersave.role = x;
            usersave.Save();
            return View();
        }
        
        public ActionResult Test()
        {
            IEnumerable<Role> datas = role.FindAll();
            ViewBag.datas = datas;
            return View();
        }
    }
}
