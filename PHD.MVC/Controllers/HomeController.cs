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

        public ActionResult SelectAddress()
        {
            User model = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("user.Id", model.Id));
            int total;
            IEnumerable<Address> address = new AddressService().FindAllByCriteria(Crit, out total, 0, 10, "id", "asc");
            ViewBag.model = model;
            ViewBag.Address = address;


            return View(model);
        }
        [HttpPost]
        public ActionResult SelectAddress(FormCollection form)
        {
            User model = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("user.Id", model.Id));
            int total;
            IEnumerable<Address> address = new AddressService().FindAllByCriteria(Crit, out total, 0, 10, "id", "asc");

            ViewBag.model = model;
            ViewBag.Address = address;

            try
            {

                foreach (Address row in address)
                {
                    if (row.Id == int.Parse(Request.Form["id_address"]))
                    {
                        row.is_main = 1;
                    }
                    else
                    {
                        row.is_main = 0;
                    }
                    row.Save();

                }

                return RedirectToAction("index", "home");
            }
            catch
            {

                return View(model);
            }
        }
        public ActionResult Register()
        {
            User model = new User();
            IEnumerable<Typeaddress> typeaddress = new TypeaddressService().FindAll();
            ViewBag.typeaddress = typeaddress;
            ViewBag.message = ""; 
            return View(model);
        }
        
        
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            StringHelper help = new StringHelper();
            User model = new User();
            string temp = Request.Form["password"];
            IEnumerable<Typeaddress> typeaddress = new TypeaddressService().FindAll();
            ViewBag.typeaddress = typeaddress;
            ViewBag.message = "";
            try
            {
                RoleService serv_role = new RoleService();
                Address address = new Address();
                Typeaddress type = new TypeaddressService().FindBy(Convert.ToInt32(Request.Form["typeaddress"]));
                address.typeaddress = type;
                address.is_main = 1;

                if (new userHelper().GetUser(Request.Form["email"]) != null)
                {
                    ViewBag.message = "Email Sudah terdaftar<br>" + ViewBag.message;
                   
                }
                if(address.typeaddress.Id == 1)
                {
                    ViewBag.message += Request.Form["id_jalan"] == "" ? "Jalan Harus Dipilih<br>":"";
                    Street street = new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"]));
                    address.street = street;
                    address.blok = Request.Form["blok"];
                    address.no_alamat = Request.Form["no_alamat"];
                    address.ket = Request.Form["ket"];
                }
                if(address.typeaddress.Id == 2)
                {   ViewBag.message += Request.Form["id_jalan"] == "" ? "Jalan Harus Dipilih<br>":"";
                    Street street =new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"]));                    //address.street = street;
                    address.street = street;

                    address.gedung = Request.Form["gedung"];
                    address.lantai = Request.Form["lantai"];
                    address.no_lantai = Request.Form["no_lantai"];
                    address.ket = Request.Form["ket"];
                }
                if(address.typeaddress.Id == 3)
                {
                    ViewBag.message += Request.Form["id_jalan"] == "" ? "Jalan Harus Dipilih<br>":"";
                    Street street = new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"]));                    //address.street = street;
                    address.street = street;

                    address.gedung = Request.Form["gedung"];
                    address.lantai = Request.Form["lantai"];
                    address.perusahaan = Request.Form["perusahaan"];
                    address.no_lantai = Request.Form["no_lantai"];
                    address.ket = Request.Form["ket"];
                }
                if(address.typeaddress.Id == 4)
                {
                    ViewBag.message += Request.Form["id_jalan"] == "" ? "Jalan Harus Dipilih<br>":""; 
                    Street street = new StreetService().FindBy(Convert.ToInt32(Request.Form["id_jalan"])) ;                    //address.street = street;
                    address.street = street;
                    address.gedung = Request.Form["gedung"];
                    address.tempat = Request.Form["tempat"];
                    address.no_tempat = Request.Form["no_tempat"];
                    address.ket = Request.Form["ket"];
                }

                //model.password = new md5helper().CalculateMD5Hash(Request.Form["password"]);
                model.password = Request.Form["password"];
                if (model.password.Contains(' ') || string.IsNullOrWhiteSpace(model.password) || model.password.Length < 6)
                {
                    ViewBag.message += "password tidak valid<br>";
                    throw new Exception();
                }
                if (model.password.Contains(' ') || string.IsNullOrWhiteSpace(model.password) || model.password.Length < 6)
                {
                    ViewBag.message += "password tidak valid<br>";
                    throw new Exception();
                }

                model.nama = help.sep(Request.Form["email"]);
                model.telepon = Request.Form["telepon"];
                model.email = Request.Form["email"];
                model.username = help.sep(model.email);
                model.tanggal_lahir = DateTime.Now;
                model.register_date = DateTime.Now;
                model.role = serv_role.FindBy(3);
                //model.role = new Role();
                //model.role.Id = 3;
                model.status = 0;
                model.Save();
                address.user = model;
                address.status = 1;
                address.Save();

                Session["barudaftar"] = "true";
                // TODO: Add insert logic here
                return RedirectToAction("index","home");
                
                // return RedirectToAction("Index");
            }
            catch
            {
                model.password = temp;
                ViewBag.message = "Registrasi anda gagal<br>"+ViewBag.message;
                return View(model);
            }
        }

        public ActionResult test()
        {
            IEnumerable<Address> address = new AddressService().FindAll();
            ViewBag.test = address;
            return View();
        }
        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Autocompleteaddress(string term)
        {
            ArrayList arraylist = new ArrayList();

            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Like("name", "%"+term+"%"));
            int total;
            IEnumerable<Street> streets = new StreetService().FindAllByCriteria(Crit, out total, 0, 10, "id", "asc");

            foreach (var row in streets)
            {
                arraylist.Add(row.name+"|"+ row.outlet.area.name);
            }
            var filteredItems = arraylist.ToArray();
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CheckBasket()
        {
            String result = "True";
            int id_outlet = 0;
            Hashtable table = new Hashtable();
            if (Session["order"] == null)
            {
                result = "2";
            }
            if (!User.Identity.IsAuthenticated)
            {
                result = "1";
            }
            else 
            {
                if (!string.IsNullOrEmpty(Request.Form["jam"]) && result != "!order")
                {
                    try
                    {
                        string time = Request.Form["jam"];
                        string date = Request.Form["date"];
                        int id_payment = 0;
                        int total = int.Parse(Request.Form["total"]);
                        if (Request.Form["payment"] != "")
                        {
                            id_payment = int.Parse(Request.Form["payment"]);
                        }
                        User current = new userHelper().GetUser(User.Identity.Name);
                        List<ICriterion> Crit = new List<ICriterion>();

                        Crit.Add(Restrictions.Eq("is_main", 1));
                        Crit.Add(Restrictions.Eq("user.id", current.Id));
                        Address alamat = new AddressService().FindByCriteria(Crit);

                       
                        Outlet outlet = alamat.street.outlet;

                        id_outlet = outlet.Id;
                        if (alamat.street.is_active == 1) //alamat aktif
                        {
                            string format = "MM/dd/yyyy HH:mm";
                            DateTime? START;
                            DateTime? END;
                            DateTime NOW = DateTime.ParseExact(date + " " + time, format, CultureInfo.InvariantCulture);
                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeMondayStart);
                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSundayEnd);

                            int today = (int)NOW.DayOfWeek;

                            switch (today)
                            {
                                case 0:
                                    START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSundayStart);
                                    END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSundayEnd);
                                    break;
                                case 1:
                                    START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeMondayStart);
                                    END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeMondayEnd);
                                    break;
                                case 2:
                                    START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeTuesdayStart);
                                    END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeTuesdayEnd);
                                    break;
                                case 3:
                                    START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeWednesdayStart);
                                    END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeWednesdayEnd);
                                    break;
                                case 4:
                                    START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeThursdayStart);
                                    END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeThursdayEnd);
                                    break;
                                case 5:
                                    START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeFridayStart);
                                    END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeFridayEnd);
                                    break;
                                case 6:
                                    END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSaturdayEnd);
                                    START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSaturdayStart);

                                    break;
                            }

                            DateTime present = DateTime.Now;

                            DateTime limit = present.AddDays(int.Parse(new DataService().FindBy(5).value));

                            if (NOW > limit)
                            {
                                result = "3";
                            }

                            while ((outlet.status != 1 || (outlet.status == 1 & (NOW > END && NOW < START))))
                            {
                                if (outlet.outlet != null)
                                {
                                    outlet = outlet.outlet;
                                    switch (today)
                                    {
                                        case 0:
                                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSundayStart);
                                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSundayEnd);
                                            break;
                                        case 1:
                                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeMondayStart);
                                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeMondayEnd);
                                            break;
                                        case 2:
                                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeTuesdayStart);
                                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeTuesdayEnd);
                                            break;
                                        case 3:
                                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeWednesdayStart);
                                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeWednesdayEnd);
                                            break;
                                        case 4:
                                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeThursdayStart);
                                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeThursdayEnd);
                                            break;
                                        case 5:
                                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeFridayStart);
                                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeFridayEnd);
                                            break;
                                        case 6:
                                            START = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSaturdayStart);
                                            END = DateTime.Parse(NOW.ToShortDateString() + " " + outlet.DeliveryTimeSaturdayEnd);
                                            break;
                                    }
                                }
                                else
                                {
                                    result = "3";
                                    break;
                                }
                            }

                            id_outlet = outlet.Id;

                            if (outlet.status == 0)
                            {

                                result = "6";
                            }

                            /*
                            if (NOW > END && NOW < START)
                            {
                                result = "3";
                            }
                            */
                            if (NOW < DateTime.Now)
                            {

                                result = "3";
                            }

                            if (id_payment != 0)
                            {
                                Payment pembayaran = new PaymentService().FindBy(id_payment);

                                if (pembayaran.bottom_limit != 0)
                                {
                                    result = pembayaran.bottom_limit > total ? "5" : result;
                                }
                            }
                        }
                        else 
                        {
                            result = "6";
                        
                        }
                    }
                    catch 
                    {
                        result = "4";
                    }
                }
            }
            table["result"] = result;
            table["id_outlet"] = id_outlet;

            return Json(table, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string term)
        {

            ArrayList arraylist = new ArrayList();

            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Like("name_long", "%" + term + "%"));
            int total;
            IEnumerable<Street> streets = new StreetService().FindAllByCriteria(Crit, out total, 0, 100, "id", "asc");
            foreach (var row in streets)
            {
                Hashtable array = new Hashtable();
                array.Add("id", row.Id);
                array.Add("value", row.name_long + " - " + row.outlet.name+" - " + row.outlet.area.name);
                array.Add("label", row.name_long + " - " + row.outlet.name+" - " + row.outlet.area.name);
               
             
                arraylist.Add( array);
            }
            var routeList = arraylist.ToArray();

            return Json(routeList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ResetAddress()
        {

            List<ICriterion> crit = new List<ICriterion>();
            crit.Add(Restrictions.Eq("role.Id", 3));

            int total;
            IEnumerable<User> AllUser= new UserService().FindAllByCriteria(crit,out total,0,100000,"Id","desc");

            foreach (User user in AllUser)
            { 
                int i = 0;
                foreach(Address address in user.Addresses)
                {
                    if (i == 0)
                    {
                        address.is_main = 1;
                    }
                    else 
                    {
                        address.is_main = 0;
                    }
                    address.status = 1;
                    address.Save();
                    i++;
                }
            
            
            }

            return Json("cool", JsonRequestBehavior.AllowGet);
        }
    }
}
