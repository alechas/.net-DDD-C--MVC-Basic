using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHD.Service.ModelService;
using PHD.Session.Classes;
using PHD.MVC.Helper;
using NHibernate.Criterion;
using System.Collections;
using System.Globalization;
namespace PHD.MVC.Controllers
{
    public class PaddictController : Controller
    {
        //
        // GET: /Paddict/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.message = "";

                User usercurrent = new userHelper().GetUser(User.Identity.Name);
                int total;
                List<ICriterion> critaddress = new List<ICriterion>();
                critaddress.Add(Restrictions.Eq("user.id", usercurrent.Id));
                critaddress.Add(Restrictions.Eq("status", 1));
                IEnumerable<Address> useraddress = new AddressService().FindAllByCriteria(critaddress, out total, 0, 100, "is_main", "ASC");
                usercurrent.Bersih();
                ViewBag.usercurrent = usercurrent;
                ViewBag.useraddress = useraddress;
                ViewBag.professions = new ProfesiService().FindAll();
                ViewBag.hobbies = new HobiService().FindAll();
                return View();
            }
            else 
            {
                return RedirectToAction("index", "home");
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (User.Identity.IsAuthenticated)
            {
                User usercurrent = new userHelper().GetUser(User.Identity.Name);
                int total;
                List<ICriterion> critaddress = new List<ICriterion>();
                critaddress.Add(Restrictions.Eq("user.id", usercurrent.Id));
                critaddress.Add(Restrictions.Eq("status",1));
                IEnumerable<Address> useraddress = new AddressService().FindAllByCriteria(critaddress, out total, 0, 100, "is_main", "ASC");

                ViewBag.usercurrent = usercurrent;
                ViewBag.useraddress = useraddress;
                ViewBag.hobbies = new HobiService().FindAll();
                ViewBag.professions = new ProfesiService().FindAll();
                ViewBag.message = "";
                string temp="";
                try
                {
                    // alter user
                    // add address
                    if (Request.Form["typeaddress"] != null && Request.Form["typeaddress"] != "")
                    {
                        Address address = new Address();
                        Typeaddress type = new TypeaddressService().FindBy(Convert.ToInt32(Request.Form["typeaddress"]));
                        address.typeaddress = type;
                        address.is_main = 0;
                        if (address.typeaddress.Id == 1)
                        {
                            Street street = new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"]));
                            address.street = street;
                            address.blok = Request.Form["blok"];
                            address.no_alamat = Request.Form["no_alamat"];
                            address.ket = Request.Form["ket"];
                        }
                        if (address.typeaddress.Id == 2)
                        {
                            Street street = new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"]));
                            address.street = street;
                            address.gedung = Request.Form["gedung"];
                            address.lantai = Request.Form["lantai"];
                            address.no_lantai = Request.Form["no_lantai"];
                            address.ket = Request.Form["ket"];
                        }
                        if (address.typeaddress.Id == 3)
                        {

                            Street street = new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"]));
                            address.street = street;
                            address.gedung = Request.Form["gedung"];
                            address.lantai = Request.Form["lantai"];
                            address.perusahaan = Request.Form["perusahaan"];
                            address.no_lantai = Request.Form["no_lantai"];
                            address.ket = Request.Form["ket"];
                        }
                        if (address.typeaddress.Id == 4)
                        {
                            Street street = new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"]));
                            address.street = street;
                            address.gedung = Request.Form["gedung"];
                            address.tempat = Request.Form["tempat"];
                            address.no_tempat = Request.Form["no_tempat"];
                            address.ket = Request.Form["ket"];
                        }

                        address.user = usercurrent;
                        address.status = 0;
                        address.Save();
                    }

                    if (Request.Form["password"] != "" && Request.Form["password"] != null && Request.Form["password"] != usercurrent.password)
                    {
                        //usercurrent.password = new md5helper().CalculateMD5Hash(Request.Form["password"]);

                        if (Request.Form["password"].Length < 5){
                            ViewBag.message = ViewBag.message + "</br>" + "Password yang Anda masukan kurang dari 6 karakter.";
                        }
                        else {
                            usercurrent.password = Request.Form["password"];
                        }
                    }
                    
                    if (Request.Form["nama"] != "" && Request.Form["nama"] != null && Request.Form["nama"] != usercurrent.nama)
                        usercurrent.nama = Request.Form["nama"];
                    if (Request.Form["telepon"] != "" && Request.Form["telepon"] != null && Request.Form["telepon"] != usercurrent.telepon)
                        usercurrent.telepon = Request.Form["telepon"];
                    if (Request.Form["tempat_lahir"] != "" && Request.Form["tempat_lahir"] != null && Request.Form["tempat_lahir"] != usercurrent.tempat_lahir)
                        usercurrent.tempat_lahir = Request.Form["tempat_lahir"];
                    if (Request.Form["tanggal_lahir"] != null && Request.Form["tanggal_lahir"] != "" && Convert.ToDateTime(Request.Form["tanggal_lahir"]) != usercurrent.tanggal_lahir)
                    {
                        IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                        string format = "dd/MM/yyyy";
                        usercurrent.tanggal_lahir = DateTime.ParseExact(Request.Form["tanggal_lahir"], format, theCultureInfo);
                        //usercurrent.tanggal_lahir = DateTime.Parse(Request.Form["tanggal_lahir"], CultureInfo.CreateSpecificCulture("fr-FR"));
                        
                       // temp = Request.Form["tanggal_lahir"];
                        
                    }
                    //usercurrent.tanggal_lahir = Convert.ToDateTime("1/1/2012 12:00:00 AM");
                    if (Request.Form["jenis_kelamin"] != "" && Request.Form["jenis_kelamin"] != null && Request.Form["jenis_kelamin"] != usercurrent.jenis_kelamin)
                        usercurrent.jenis_kelamin = Request.Form["jenis_kelamin"];
                    if (Request.Form["profesi"] != "" && Request.Form["profesi"] != null && Request.Form["profesi"] != usercurrent.profesi)
                        usercurrent.prof = new ProfesiService().FindBy(int.Parse(Request.Form["profesi"]));
                    if (Request.Form["hobi"] != "" && Request.Form["hobi"] != null && Request.Form["hobi"] != usercurrent.hobi)
                        {//usercurrent.hobi = Request.Form["hobi"];
                            usercurrent.hobirel = new HobiService().FindBy(int.Parse(Request.Form["hobi"]));
                        }
                    if (Request.Form["fav_hangout"] != "" && Request.Form["fav_hangout"] != null && Request.Form["fav_hangout"] != usercurrent.fav_hangout)
                        usercurrent.fav_hangout = Request.Form["fav_hangout"];
                    if (Request.Form["fav_makanan"] != "" && Request.Form["fav_makanan"] != null && Request.Form["fav_makanan"] != usercurrent.fav_makanan)
                        usercurrent.fav_makanan = Request.Form["fav_makanan"];
                    if (Request.Form["fav_lokasi"] != "" && Request.Form["fav_lokasi"] != null && Request.Form["fav_lokasi"] != usercurrent.fav_lokasi)
                        usercurrent.fav_lokasi = Request.Form["fav_lokasi"];
                    if (Request.Form["fav_brands"] != "" && Request.Form["fav_brands"] != null && Request.Form["fav_brands"] != usercurrent.fav_brands)
                        usercurrent.fav_brands = Request.Form["fav_brands"];

                    if (Request.Form["del_address"] != "" && Request.Form["del_address"] != null )
                    {

                        Address addresstodel = new AddressService().FindBy(int.Parse(Request.Form["del_address"]));
                        addresstodel.status = -1;
                        addresstodel.Save();

                    }

                    usercurrent.Save();


                    // TODO: Add insert logic here

                    return View();
                }
                catch(Exception e)
                {
                    ViewBag.message = "Edit profile anda gagal<br>" + ViewBag.message;
                    return View();
                }
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }

        public ActionResult OrderHistory()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }

            string username = User.Identity.Name;
            User user = new userHelper().GetUser(username);

            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritOrdercust = new List<ICriterion>();
            List<ICriterion> CritOrdersubmenu = new List<ICriterion>();
            List<ICriterion> Critsubmenu = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritOrdercust.Add(Restrictions.Eq("user.Id", user.Id));
            int total2;
            IEnumerable<Ordercust> ordercustall = new OrdercustService().FindAllByCriteria(CritOrdercust, out total2, 0, 200, "Id", "DESC");

            List<int> idsbm = new List<int>();
            foreach (Ordercust item in ordercustall)
            {
                idsbm.Add(item.Id);
            }
            idsbm.Distinct();
            CritOrdersubmenu.Add(Restrictions.In("id_order", idsbm));

            int total3;
            IEnumerable<Ordersubmenu> ordersubmenuall = new OrdersubmenuService().FindAllByCriteria(CritOrdersubmenu, out total3, 0, 200, "Id", "ASC").Distinct();

            User usercurrent = new userHelper().GetUser(User.Identity.Name);
            ViewBag.usercurrent = usercurrent; 

            ViewBag.ordersubmenuall = ordersubmenuall;
            ViewBag.ordercustall = ordercustall;
            ViewBag.menu = menu;
            //ViewBag.os = os;

            return View();
        }

        [HttpPost]
        public ActionResult OrderHistory(FormCollection form)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }

            string username = User.Identity.Name;
            User user = new userHelper().GetUser(username);

            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritOrdercust = new List<ICriterion>();
            List<ICriterion> CritOrdersubmenu = new List<ICriterion>();
            List<ICriterion> Critsubmenu = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritOrdercust.Add(Restrictions.Eq("user.Id", user.Id));
            int total2;
            IEnumerable<Ordercust> ordercustall = new OrdercustService().FindAllByCriteria(CritOrdercust, out total2, 0, 200, "Id", "ASC");

            foreach (Ordercust item in ordercustall)
            {
                CritOrdersubmenu.Add(Restrictions.Eq("id_order", item.Id));
            }

            int total3;
            IEnumerable<Ordersubmenu> ordersubmenuall = new OrdersubmenuService().FindAllByCriteria(CritOrdersubmenu, out total3, 0, 200, "Id", "ASC").Distinct();


            User usercurrent = new userHelper().GetUser(User.Identity.Name);
            ViewBag.usercurrent = usercurrent;

            ViewBag.ordersubmenuall = ordersubmenuall;
            ViewBag.ordercustall = ordercustall;
            ViewBag.menu = menu;
            
              /*******************/
             // ajouter l'order //
            /*******************/

            int id_order = Convert.ToInt16(Request.Form["hidval"]);
            string kodeorder = null;

            List<ICriterion> Critnewsubmenu = new List<ICriterion>();
            List<ICriterion> Critnewordersubmenu = new List<ICriterion>();
            Critnewordersubmenu.Add(Restrictions.Eq("id_order", id_order));

            int total4;
            IEnumerable<Ordersubmenu> newordersubmenu = new OrdersubmenuService().FindAllByCriteria(Critnewordersubmenu, out total4, 0, 200, "Id", "ASC");

            List<int> idsbm = new List<int>();
            foreach (Ordersubmenu item in newordersubmenu)
            {
                //Critsubmenu.Add(Restrictions.Eq("Id", item.id_submenu));
                idsbm.Add(item.id_submenu);
            }

            Critnewsubmenu.Add(Restrictions.In("Id", idsbm));
            int total5;
            IEnumerable<Submenu> newsubmenu = new SubmenuService().FindAllByCriteria(Critnewsubmenu, out total5, 0, 200, "Id", "ASC");

            // creer l'order

            foreach (Submenu sm in newsubmenu)
            {
                kodeorder = sm.kode;
                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    order.Add(kodeorder);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];
                    order.Add(kodeorder);
                    Session["order"] = order;
                }
            }

            return View();
        }

        public ActionResult Point()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<ICriterion> CritReedem = new List<ICriterion>();
                CritReedem.Add(Restrictions.Eq("status", 1));
                int total;
                IEnumerable<Reedem> reedemall = new ReedemService().FindAllByCriteria(CritReedem, out total, 0, 100, "id", "ASC");

                User usercurrent = new userHelper().GetUser(User.Identity.Name);

                ViewBag.reedemall = reedemall;
                ViewBag.usercurrent = usercurrent;

                return View();
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }

        [HttpPost]
        public ActionResult Point(FormCollection form)
        {
            if (User.Identity.IsAuthenticated)
            {
                List<ICriterion> CritReedem = new List<ICriterion>();
                CritReedem.Add(Restrictions.Eq("status", 1));
                int total;
                IEnumerable<Reedem> reedemall = new ReedemService().FindAllByCriteria(CritReedem, out total, 0, 100, "id", "ASC");

                User usercurrent = new userHelper().GetUser(User.Identity.Name);

                ViewBag.reedemall = reedemall;
                ViewBag.usercurrent = usercurrent;

                // create user reedem
                int idreedem = Convert.ToInt16(Request.Form["idreedem"]);
                Userreedem model = new Userreedem();

                Reedem reedem = new ReedemService().FindBy(idreedem);

                model.id_reedem = idreedem;
                model.id_user = usercurrent.Id;
                model.prev_point = reedem.point;
                model.current_point = model.prev_point - reedem.point;
                model.date_reedem = DateTime.Now;
                model.Save();

                return View();
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }

    }
}
