using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Criterion;
using NHibernate;
using PHD.Service.ModelService;
using PHD.Session.Classes;
using System.Collections;
using PHD.MVC.Helper;
using PHD.MVC.Models;
using PHD.Session.SessionStorage;

using System.Globalization;

namespace PHD.MVC.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {

            return RedirectToAction("Promo");
        }

        public ActionResult Order()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }
            
                return RedirectToAction("Index", "Menu");
            
        }
        public ActionResult Promo()
        {
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritHotpromo = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            ViewBag.menu = menu;

            CritHotpromo.Add(Restrictions.Eq("status", 1));
            CritHotpromo.Add(Restrictions.Eq("id_typemenu", 2));
            int total2;
            IEnumerable<Menu> menupromo = new MenuService().FindAllByCriteria(CritHotpromo, out total2, 0, 6, "sequence", "ASC");
            ViewBag.menupromo = menupromo;
            return View();
        }

        [HttpPost]
        public ActionResult Promo(FormCollection form)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }

            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritModifier = new List<ICriterion>();
            List<ICriterion> CritHotpromo = new List<ICriterion>();



            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            foreach (Menu menududu in menu)
            {
                menududu.Bersih();
            }
            ViewBag.menu = menu;

            CritHotpromo.Add(Restrictions.Eq("status", 1));
            CritHotpromo.Add(Restrictions.Eq("id_typemenu", 2));
            int total2;
            IEnumerable<Menu> menupromo = new MenuService().FindAllByCriteria(CritHotpromo, out total2, 0, 6, "sequence", "ASC");
            foreach (Menu menulala in menupromo) {
                menulala.Bersih();
            }
            ViewBag.menupromo = menupromo;



            // add order
            // retrieve kode order
            int idpromo = Convert.ToInt16(Request.Params["hidvalue"]);
            Menu menucurrent = new MenuService().FindBy(idpromo);
            CritModifier.Add(Restrictions.Eq("menu.Id", menucurrent.Id));
            IEnumerable<Modifier> Modifiers = new ModifierService().FindAllByCriteria(CritModifier,out total,0,10,"id","asc");

            if (Modifiers.Count()>0) // kalau bukan paket valentine (kalau promo double)
            {
                return RedirectToAction("PromoDetail", new { id = idpromo});
            }

            List<ICriterion> Critsubmenuordered = new List<ICriterion>();
            Critsubmenuordered.Add(Restrictions.Eq("status", 1));
            Critsubmenuordered.Add(Restrictions.Eq("menu.id", idpromo));
            Submenu submenuordered = new SubmenuService().FindByCriteria(Critsubmenuordered);
            string kodeorder = submenuordered.kode;

            
            User currentuser = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", currentuser.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", submenuordered.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {

                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(kodeorder);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == kodeorder)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(kodeorder);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else 
            {
                Session["habis"] = true;
            
            }
            return Redirect(Request.UrlReferrer.ToString());

            //return View();
        }

        public ActionResult PromoDetail(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> Critsubmenupromo = new List<ICriterion>();
            List<ICriterion> Critmodpromo = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            foreach (Menu menududu in menu)
            {
                menududu.Bersih();
            }
            ViewBag.menu = menu;

            Critsubmenupromo.Add(Restrictions.Eq("status", 1));
            Critsubmenupromo.Add(Restrictions.Eq("menu.Id", id));
            Submenu submenupromo = new SubmenuService().FindByCriteria(Critsubmenupromo);
            submenupromo.Bersih();
            ViewBag.submenupromo = submenupromo;

            Critmodpromo.Add(Restrictions.Eq("status", 1));
            Critmodpromo.Add(Restrictions.Eq("menu.Id", id));
            int total2;
            IEnumerable<Modifier> modpromoall = new ModifierService().FindAllByCriteria(Critmodpromo, out total2, 0, 50, "sequence", "ASC");
            foreach (Modifier modpromo in modpromoall)
            {
                modpromo.Bersih();
            }
            ViewBag.modpromoall = modpromoall;
            ViewBag.data = submenupromo.menu.Id;

            return View();
        }

        [HttpPost]
        public ActionResult PromoDetail(FormCollection form, int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> Critsubmenupromo = new List<ICriterion>();
            List<ICriterion> Critmodpromo = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            foreach (Menu menududu in menu)
            {
                menududu.Bersih();
            }
            ViewBag.menu = menu;

            Critsubmenupromo.Add(Restrictions.Eq("status", 1));
            Critsubmenupromo.Add(Restrictions.Eq("menu.Id", id));
            Submenu submenupromo = new SubmenuService().FindByCriteria(Critsubmenupromo);
            submenupromo.Bersih();
            ViewBag.submenupromo = submenupromo;

            Critmodpromo.Add(Restrictions.Eq("status", 1));
            Critmodpromo.Add(Restrictions.Eq("menu.Id", id));
            int total2;
            IEnumerable<Modifier> modpromoall = new ModifierService().FindAllByCriteria(Critmodpromo, out total2, 0, 50, "sequence", "ASC");
            foreach (Modifier modpromo in modpromoall)
            {
                modpromo.Bersih();
            }
            ViewBag.modpromoall = modpromoall;
            ViewBag.data = submenupromo.menu.Id;

            /*******************/
            // buat kode order //
            /*******************/

            string kodeorder = null;
            string kodemodifier = null;
            string kodesubmenu = submenupromo.kode;
            int id_mod1 = Convert.ToInt16(Request.Form["modifier0"]);
            int id_mod2 = Convert.ToInt16(Request.Form["modifier1"]);

            Modifier modifier1 = new ModifierService().FindBy(id_mod1);
            Modifier modifier2 = new ModifierService().FindBy(id_mod2);

            kodemodifier = modifier1.kode + "-" + modifier2.kode;
            kodeorder = kodesubmenu + "+" + kodemodifier;

            // retrieve box
            if (Request.Form["box"] != "")
            {
                int idbox = Convert.ToInt16(Request.Form["box"]);
                Box box = new BoxService().FindBy(idbox);
                string kodebox = box.kode;
                kodeorder = kodeorder + '-' + kodebox;
            }
                        
            /******************/
            // buat order //
            /*****************/
            
            User currentuser = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", currentuser.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", submenupromo.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {


                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(kodeorder);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == kodeorder)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(kodeorder);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else 
            {
                Session["habis"] = true;
            }
            return View();
        }


        public ActionResult DoublePizza()
        {
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritHotpromo = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            ViewBag.menu = menu;

            CritHotpromo.Add(Restrictions.Eq("status", 1));
            CritHotpromo.Add(Restrictions.Eq("id_typemenu", 5));
            int total2;
            IEnumerable<Menu> menudouble = new MenuService().FindAllByCriteria(CritHotpromo, out total2, 0, 6, "sequence", "ASC");
            ViewBag.menudouble = menudouble;

            return View();
        }

        [HttpPost]
        public ActionResult DoublePizza(FormCollection form)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }

            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritHotpromo = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            foreach (Menu menududu in menu)
            {
                menududu.Bersih();
            }
            ViewBag.menu = menu;

            CritHotpromo.Add(Restrictions.Eq("status", 1));
            CritHotpromo.Add(Restrictions.Eq("id_typemenu", 5));
            int total2;
            IEnumerable<Menu> menudouble = new MenuService().FindAllByCriteria(CritHotpromo, out total2, 0, 6, "sequence", "ASC");
            foreach (Menu menulala in menudouble)
            {
                menulala.Bersih();
            }
            ViewBag.menudouble = menudouble;

            // add order
            // retrieve kode order
            int idpromo = Convert.ToInt16(Request.Params["hidvalue"]);
            Menu menucurrent = new MenuService().FindBy(idpromo);

            return RedirectToAction("doubleDetail", new { id = idpromo });

            List<ICriterion> Critsubmenuordered = new List<ICriterion>();
            Critsubmenuordered.Add(Restrictions.Eq("status", 1));
            Critsubmenuordered.Add(Restrictions.Eq("menu.id", idpromo));
            Submenu submenuordered = new SubmenuService().FindByCriteria(Critsubmenuordered);
            string kodeorder = submenuordered.kode;

            
            User currentuser = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", currentuser.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", submenuordered.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {

                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(kodeorder);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == kodeorder)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(kodeorder);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else
            {
                Session["habis"] = true;
            }
            return Redirect(Request.UrlReferrer.ToString());

            //return View();
        }

        public ActionResult DoubleDetail(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> Critsubmenupromo = new List<ICriterion>();
            List<ICriterion> Critmodpromo = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            foreach (Menu menududu in menu)
            {
                menududu.Bersih();
            }
            ViewBag.menu = menu;

            Critsubmenupromo.Add(Restrictions.Eq("status", 1));
            Critsubmenupromo.Add(Restrictions.Eq("menu.Id", id));
            Submenu submenupromo = new SubmenuService().FindByCriteria(Critsubmenupromo);
            submenupromo.Bersih();
            ViewBag.submenupromo = submenupromo;

            Critmodpromo.Add(Restrictions.Eq("status", 1));
            Critmodpromo.Add(Restrictions.Eq("menu.Id", id));
            int total2;
            IEnumerable<Modifier> modpromoall = new ModifierService().FindAllByCriteria(Critmodpromo, out total2, 0, 50, "sequence", "ASC");
            foreach (Modifier modpromo in modpromoall)
            {
                modpromo.Bersih();
            }
            ViewBag.modpromoall = modpromoall;
            ViewBag.data = submenupromo.menu.Id;

            return View();
        }

        [HttpPost]
        public ActionResult DoubleDetail(FormCollection form, int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> Critsubmenupromo = new List<ICriterion>();
            List<ICriterion> Critmodpromo = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");
            foreach (Menu menududu in menu)
            {
                menududu.Bersih();
            }
            ViewBag.menu = menu;

            Critsubmenupromo.Add(Restrictions.Eq("status", 1));
            Critsubmenupromo.Add(Restrictions.Eq("menu.Id", id));
            Submenu submenupromo = new SubmenuService().FindByCriteria(Critsubmenupromo);
            submenupromo.Bersih();
            ViewBag.submenupromo = submenupromo;

            Critmodpromo.Add(Restrictions.Eq("status", 1));
            Critmodpromo.Add(Restrictions.Eq("menu.Id", id));
            int total2;
            IEnumerable<Modifier> modpromoall = new ModifierService().FindAllByCriteria(Critmodpromo, out total2, 0, 50, "sequence", "ASC");
            foreach (Modifier modpromo in modpromoall)
            {
                modpromo.Bersih();
            }
            ViewBag.modpromoall = modpromoall;
            ViewBag.data = submenupromo.menu.Id;

            /*******************/
            // buat kode order //
            /*******************/

            string kodeorder = null;
            string kodemodifier = null;
            string kodesubmenu = submenupromo.kode;
            int id_mod1 = Convert.ToInt16(Request.Form["modifier0"]);
            int id_mod2 = Convert.ToInt16(Request.Form["modifier1"]);

            Modifier modifier1 = new ModifierService().FindBy(id_mod1);
            Modifier modifier2 = new ModifierService().FindBy(id_mod2);

            kodemodifier = modifier1.kode + "-" + modifier2.kode;
            kodeorder = kodesubmenu + "+" + kodemodifier;

            // retrieve box
            if (Request.Form["box"] != "")
            {
                int idbox = Convert.ToInt16(Request.Form["box"]);
                Box box = new BoxService().FindBy(idbox);
                string kodebox = box.kode;
                kodeorder = kodeorder + '-' + kodebox;
            }

            /******************/
            // buat order //
            /*****************/

            
            User currentuser = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", currentuser.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", submenupromo.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {

                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(kodeorder);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == kodeorder)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(kodeorder);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else 
            {
                Session["habis"] = true;
            
            }

            return View();
        }





        public ActionResult Hemat(int? idhemat)
        {
            
            if (!idhemat.HasValue)
            {
                List<ICriterion> critmenutop = new List<ICriterion>();
                critmenutop.Add(Restrictions.Eq("id_typemenu", 3));
                Menu menutop = new MenuService().FindByCriteria(critmenutop);
                idhemat = menutop.Id;
            }
            int id = Convert.ToInt16(idhemat);
            Menu menucurrent = new MenuService().FindBy(id);
            int total, total1, total2;
            List<ICriterion> CritHemat = new List<ICriterion>();
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritSubmenu = new List<ICriterion>();
            List<ICriterion> CritModifier = new List<ICriterion>();
            
            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));

            IEnumerable<Menu> menuall = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritModifier.Add(Restrictions.Eq("status", 1));
            CritModifier.Add(Restrictions.Eq("menu.id", id));

            IEnumerable<Modifier> modifiers = new ModifierService().FindAllByCriteria(CritModifier, out total2, 0, 100, "sequence", "ASC");

            CritSubmenu.Add(Restrictions.Eq("status", 1));
            CritSubmenu.Add(Restrictions.Eq("menu.id", id));

            Submenu submenucurrent = new SubmenuService().FindByCriteria(CritSubmenu);

            CritHemat.Add(Restrictions.Eq("status", 1));
            CritHemat.Add(Restrictions.Eq("id_typemenu", 3));

            IEnumerable<Menu> menuhematall = new MenuService().FindAllByCriteria(CritHemat, out total1, 0, 6, "sequence", "ASC");

            ViewBag.menucurrent = menucurrent;
            ViewBag.menu = menuall;
            ViewBag.menuhemat = menuhematall;
            ViewBag.submenucurrent = submenucurrent;
            ViewBag.modifiers = modifiers;
            ViewBag.data = id;

            return View();
        }

        [HttpPost]
        public ActionResult Hemat(FormCollection form, int? idhemat)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }

            if (!idhemat.HasValue)
            {
                List<ICriterion> critmenutop = new List<ICriterion>();
                critmenutop.Add(Restrictions.Eq("id_typemenu", 3));
                Menu menutop = new MenuService().FindByCriteria(critmenutop);
                idhemat = menutop.Id;
            }
            int id = Convert.ToInt16(idhemat);
            
            Menu menucurrent = new MenuService().FindBy(id);
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritHemat = new List<ICriterion>();
            List<ICriterion> CritSubmenu = new List<ICriterion>();
            List<ICriterion> CritModifier = new List<ICriterion>();

            int total, total1, total2;

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));

            IEnumerable<Menu> menuall = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritHemat.Add(Restrictions.Eq("status", 1));
            CritHemat.Add(Restrictions.Eq("id_typemenu", 3));

            IEnumerable<Menu> menuhematall = new MenuService().FindAllByCriteria(CritHemat, out total1, 0, 6, "sequence", "ASC");

            CritSubmenu.Add(Restrictions.Eq("status", 1));
            CritSubmenu.Add(Restrictions.Eq("menu.id", id));

            Submenu submenucurrent = new SubmenuService().FindByCriteria(CritSubmenu);

            CritModifier.Add(Restrictions.Eq("status", 1));
            CritModifier.Add(Restrictions.Eq("menu.id", id));

            IEnumerable<Modifier> modifiers = new ModifierService().FindAllByCriteria(CritModifier, out total2, 0, 100, "sequence", "ASC");

            ViewBag.menucurrent = menucurrent;
            ViewBag.menu = menuall;
            ViewBag.menuhemat = menuhematall;
            ViewBag.submenucurrent = submenucurrent;
            ViewBag.modifiers = modifiers;
            ViewBag.data = id;

            // add order
            string kodemodifiersordered = null;
            int idpizza = 0;

            List<ICriterion> CritOrder = new List<ICriterion>();

            CritOrder.Add(Restrictions.Eq("status", 1));
            CritOrder.Add(Restrictions.Eq("menu.id", id));
            CritOrder.Add(Restrictions.Eq("position", 0));

            int total3;
            IEnumerable<Modifier> modifierseq = new ModifierService().FindAllByCriteria(CritOrder, out total3, 0, 100, "sequence", "ASC");

            int i = 0;
            int[] arridmodorder = new int[50];
            foreach (var model in modifierseq)
            {
                if (model != null && model.htmlclass != "hidden")
                {
                    if (Request.Form["modifier" + model.sequence + ""] != null)
                    {
                        int idmodorder = Convert.ToInt32(Request.Form["modifier" + model.sequence + ""]);
                        arridmodorder[i] = idmodorder;
                        Modifier ModifierOrder = new ModifierService().FindBy(idmodorder);

                        if (ModifierOrder.modifier != null && ModifierOrder.modifier.Id != 0)
                        {
                            if (arridmodorder.Contains(ModifierOrder.modifier.Id))
                            {
                                kodemodifiersordered = kodemodifiersordered + ModifierOrder.kode + '-';
                            }
                        }
                        else if (!model.htmlclass.Contains("nav-choice") && ModifierOrder.sequence != 0)
                        {
                            kodemodifiersordered = kodemodifiersordered + ModifierOrder.kode + '-';
                        }
                        else if (!model.htmlclass.Contains("nav-choice") && ModifierOrder.sequence == 0)
                        {
                            idpizza = ModifierOrder.Id;
                        }
                    }
                }
                i++;
            }
            kodemodifiersordered = kodemodifiersordered.Remove(kodemodifiersordered.Length - 1) ;

            return RedirectToAction("HematUpgrade",new { id = id, kode=kodemodifiersordered, idpizza = idpizza });
        }

        public ActionResult HematUpgrade(int id, string kode, int idpizza)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }
            
            Menu menucurrent = new MenuService().FindBy(id);
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritHemat = new List<ICriterion>();
            List<ICriterion> CritSubmenu = new List<ICriterion>();

            int total, total1;

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));

            IEnumerable<Menu> menuall = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritHemat.Add(Restrictions.Eq("status", 1));
            CritHemat.Add(Restrictions.Eq("id_typemenu", 3));

            IEnumerable<Menu> menuhematall = new MenuService().FindAllByCriteria(CritHemat, out total1, 0, 6, "sequence", "ASC");

            CritSubmenu.Add(Restrictions.Eq("status", 1));
            CritSubmenu.Add(Restrictions.Eq("menu.id", id));

            Submenu submenucurrent = new SubmenuService().FindByCriteria(CritSubmenu);
            IEnumerable<Submenu> submenuall = new SubmenuService().FindAllByCriteria(CritSubmenu, out total1, 0, 6, "Id", "ASC");

            ViewBag.menucurrent = menucurrent;
            ViewBag.menu = menuall;
            ViewBag.menuhemat = menuhematall;
            ViewBag.submenucurrent = submenucurrent;
            ViewBag.submenuall = submenuall;

            return View();
        }

        [HttpPost]
        public ActionResult HematUpgrade(FormCollection form, int id, string kode, int idpizza)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }

            Menu menucurrent = new MenuService().FindBy(id);
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritHemat = new List<ICriterion>();
            List<ICriterion> CritSubmenu = new List<ICriterion>();

            int total, total1;

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));

            IEnumerable<Menu> menuall = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritHemat.Add(Restrictions.Eq("status", 1));
            CritHemat.Add(Restrictions.Eq("id_typemenu", 3));

            IEnumerable<Menu> menuhematall = new MenuService().FindAllByCriteria(CritHemat, out total1, 0, 6, "sequence", "ASC");

            CritSubmenu.Add(Restrictions.Eq("status", 1));
            CritSubmenu.Add(Restrictions.Eq("menu.id", id));

            Submenu submenucurrent = new SubmenuService().FindByCriteria(CritSubmenu);
            IEnumerable<Submenu> submenuall = new SubmenuService().FindAllByCriteria(CritSubmenu, out total1, 0, 6, "Id", "ASC");

            ViewBag.menucurrent = menucurrent;
            ViewBag.menu = menuall;
            ViewBag.menuhemat = menuhematall;
            ViewBag.submenucurrent = submenucurrent;
            ViewBag.submenuall = submenuall;

            // retrieve kode order
            string kodesubmenuordered = null;
            string kodepizza = null;
            string kodemodifiersordered = kode;
            List<ICriterion> CritUpgrade = new List<ICriterion>();

            int idupgrade = Convert.ToInt16(Request.Form["upgradepizza"]);
            Submenu submenuchoosen = new SubmenuService().FindBy(idupgrade);
            kodesubmenuordered = submenuchoosen.kode;
            Modifier modifierchoosen = new ModifierService().FindBy(idpizza); 

            
            if (submenuchoosen.kodejenis == "OR/R")
            {
                
                kodepizza = modifierchoosen.kode;
            }
            else {
                CritUpgrade.Add(Restrictions.Eq("kodejenis", submenuchoosen.kodejenis));
                CritUpgrade.Add(Restrictions.Eq("kode_modifier", modifierchoosen.kode));
                CritUpgrade.Add(Restrictions.Eq("kategori", "Upgrade16"));
                Upgrade upgradecurrent = new UpgradeService().FindByCriteria(CritUpgrade);

                kodepizza = upgradecurrent.code;
            }

            string kodeorder = kodesubmenuordered + '+' + kodepizza + '-' + kodemodifiersordered;

             User currentuser = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", currentuser.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

           

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", submenuchoosen.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {


                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(kodeorder);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == kodeorder)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(kodeorder);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else
            {
                Session["habis"] = true;
            
            }

            return View();
        }

        public ActionResult HotMenu()
        {
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritHotmenu = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            int total;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritHotmenu.Add(Restrictions.Eq("status", 1));
            CritHotmenu.Add(Restrictions.Eq("id_typemenu", 4));
            int total2;
            IEnumerable<Menu> menuhemat = new MenuService().FindAllByCriteria(CritHotmenu, out total2, 0, 6, "sequence", "ASC");

            ViewBag.menu = menu;
            ViewBag.menuhemat = menuhemat;
            return View();
        }

        public ActionResult Favorite()
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
            IEnumerable<Ordercust> ordercustall= new OrdercustService().FindAllByCriteria(CritOrdercust, out total2, 0, 200, "Id", "ASC");

            List<int> idorcust = new List<int>();
            foreach (Ordercust item in ordercustall){
                //CritOrdersubmenu.Add(Restrictions.Eq("id_order", item.Id));
                idorcust.Add(item.Id);
            }
            idorcust.Distinct();
            CritOrdersubmenu.Add(Restrictions.In("id_order", idorcust));
            
            int total3;
            IEnumerable<Ordersubmenu> ordersubmenuall = new OrdersubmenuService().FindAllByCriteria(CritOrdersubmenu, out total3, 0, 200, "Id", "ASC");

            List<int> idsbm = new List<int>();
            foreach (Ordersubmenu item in ordersubmenuall) {
                Submenu sm = new SubmenuService().FindBy(item.id_submenu);               

                //List<ICriterion> critmen = new List<ICriterion>();
                //.Add(Restrictions.Eq("Id", sm.menu.Id));
                //Menu men = new MenuService().FindByCriteria(critmen);
                
                Menu men = new MenuService().FindBy(sm.menu.Id);
                if (men.id_typemenu == 1)
                {
                    idsbm.Add(item.id_submenu);
                }
            }
            idsbm.Distinct();
            Critsubmenu.Add(Restrictions.In("Id", idsbm));
            Critsubmenu.Add(Restrictions.Eq("status", 1));

            int total4;
            IEnumerable<Submenu> submenuordered = new SubmenuService().FindAllByCriteria(Critsubmenu, out total4, 0, 200, "Id", "ASC");
            
            //var os = submenuordered.GroupJoin(ordersubmenuall, (submenu => submenu.Id), (ordersubmenu => ordersubmenu.id_submenu), (submenu, ordersubmenu) => new { idsubmenu = submenu.Id });
               
            ViewBag.ordersubmenuall = ordersubmenuall;
            ViewBag.ordercustall = ordercustall;
            ViewBag.submenuordered = submenuordered;
            ViewBag.menu = menu;
            //ViewBag.os = os;

            return View();
        }

        [HttpPost]
        public ActionResult Favorite(FormCollection form)
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

            List<int> idorcust = new List<int>();
            foreach (Ordercust item in ordercustall)
            {
                //CritOrdersubmenu.Add(Restrictions.Eq("id_order", item.Id));
                idorcust.Add(item.Id);
            }
            CritOrdersubmenu.Add(Restrictions.In("id_order", idorcust));

            int total3;
            IEnumerable<Ordersubmenu> ordersubmenuall = new OrdersubmenuService().FindAllByCriteria(CritOrdersubmenu, out total3, 0, 200, "Id", "ASC");

            List<int> idsbm = new List<int>();
            foreach (Ordersubmenu item in ordersubmenuall)
            {
                idsbm.Add(item.id_submenu);
            }

            Critsubmenu.Add(Restrictions.In("Id", idsbm));
            int total4;
            IEnumerable<Submenu> submenuordered = new SubmenuService().FindAllByCriteria(Critsubmenu, out total4, 0, 200, "Id", "ASC");

            //var os = submenuordered.GroupJoin(ordersubmenuall, (submenu => submenu.Id), (ordersubmenu => ordersubmenu.id_submenu), (submenu, ordersubmenu) => new { idsubmenu = submenu.Id });

            ViewBag.ordersubmenuall = ordersubmenuall;
            ViewBag.ordercustall = ordercustall;
            ViewBag.submenuordered = submenuordered;
            ViewBag.menu = menu;
            //ViewBag.os = os;

            /*******************/
            // ajouter l'order //
            /*******************/

            int id_submenu = Convert.ToInt16(Request.Form["hidval"]);
            Submenu newsubmenu = new SubmenuService().FindBy(id_submenu);
            string kodeorder = newsubmenu.kode;

            // creer l'order

            User currentuser = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", currentuser.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", newsubmenu.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {

                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(kodeorder);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == kodeorder)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(kodeorder);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else 
            {
                Session["habis"] = true;
            
            }
            return View();
        }

        public ActionResult MenuUtama(int id)
        {
            Menu current = new MenuService().FindBy(id);
            List<ICriterion> Crit = new List<ICriterion>();
            List<ICriterion> CritModifier = new List<ICriterion>();
            List<ICriterion> CritSubmenu = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("id_typemenu", 1));
            
            int total, total2;
            IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

            CritModifier.Add(Restrictions.Eq("status", 1));
            //CritJenisPizza.Add(Restrictions.Eq("position", 0));
            CritModifier.Add(Restrictions.Eq("menu.id", id));

            IEnumerable<Modifier> modifiers = new ModifierService().FindAllByCriteria(CritModifier, out total2, 0, 100, "sequence", "ASC");

            CritSubmenu.Add(Restrictions.Eq("status", 1));
            //CritJenisPizza.Add(Restrictions.Eq("position", 0));
            CritSubmenu.Add(Restrictions.Eq("menu.id", id));

            IEnumerable<Submenu> submenu = new SubmenuService().FindAllByCriteria(CritSubmenu, out total2, 0, 100, "prizegroup.id", "ASC");

            ViewBag.current = current;
            ViewBag.menu = menu;
            ViewBag.modifiers = modifiers; 
            ViewBag.submenu = submenu;
            ViewBag.data = id;
            return View();
        }

        [HttpPost]
        public ActionResult MenuUtama(FormCollection form, int id)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Logon", "Account");
                }

                // initial
                Menu current = new MenuService().FindBy(id);

                List<ICriterion> Crit = new List<ICriterion>();
                List<ICriterion> CritModifier = new List<ICriterion>();
                List<ICriterion> CritSubmenu = new List<ICriterion>();

                Crit.Add(Restrictions.Eq("status", 1));
                Crit.Add(Restrictions.Eq("id_typemenu", 1));

                int total, total2;
                IEnumerable<Menu> menu = new MenuService().FindAllByCriteria(Crit, out total, 0, 6, "sequence", "ASC");

                CritModifier.Add(Restrictions.Eq("status", 1));
                CritModifier.Add(Restrictions.Eq("menu.id", id));

                IEnumerable<Modifier> modifiers = new ModifierService().FindAllByCriteria(CritModifier, out total2, 0, 100, "sequence", "ASC");

                CritSubmenu.Add(Restrictions.Eq("status", 1));
                CritSubmenu.Add(Restrictions.Eq("menu.id", id));

                IEnumerable<Submenu> submenu = new SubmenuService().FindAllByCriteria(CritSubmenu, out total2, 0, 100, "id", "ASC");

                ViewBag.current = current;
                ViewBag.menu = menu;
                ViewBag.modifiers = modifiers;
                ViewBag.submenu = submenu;
                ViewBag.data = id;

                // add order
                string kodeweborder = null;

                List<ICriterion> CritOrder = new List<ICriterion>();

                CritOrder.Add(Restrictions.Eq("status", 1));
                CritOrder.Add(Restrictions.Eq("menu.id", id));
                CritOrder.Add(Restrictions.Eq("position", 0));

                int total3;
                IEnumerable<Modifier> modifierseq = new ModifierService().FindAllByCriteria(CritOrder, out total3, 0, 6, "sequence", "ASC");

                // int i = 0;
                foreach (var model in modifierseq)
                {
                    try
                    {
                        string tempmod = Request.Form["modifier" + model.sequence];
                        if (tempmod.Contains(','))
                        {
                            List<string> idmodlist = tempmod.Split(',').ToList();
                            foreach (string idmod in idmodlist)
                            {
                                int idmodorder = Convert.ToInt32(idmod);
                                Modifier ModifierOrder = new ModifierService().FindBy(idmodorder);

                                kodeweborder = kodeweborder + ModifierOrder.kode + '-';
                            }
                        }
                        else
                        {
                            int idmodorder = Convert.ToInt32(tempmod);
                            Modifier ModifierOrder = new ModifierService().FindBy(idmodorder);

                            kodeweborder = kodeweborder + ModifierOrder.kode + '-';
                        }
                    }
                    catch 
                    { 
                    
                    }
                }
                kodeweborder = kodeweborder.Remove(kodeweborder.Length - 1);
                kodeweborder = current.kode + '+' + kodeweborder;

                // retrieve kode order
                List<ICriterion> Critsubmenuordered = new List<ICriterion>();
                Critsubmenuordered.Add(Restrictions.Eq("kode_web", kodeweborder));
                Critsubmenuordered.Add(Restrictions.Eq("menu.id", id));
                Submenu submenuordered = new SubmenuService().FindByCriteria(Critsubmenuordered);
                string kodeorder = submenuordered.kode;

                // retrieve box
                if (Request.Form["box"] != "")
                {
                    try
                    {
                        int idbox = Convert.ToInt16(Request.Form["box"]);
                        Box box = new BoxService().FindBy(idbox);
                        string kodebox = box.kode;
                        kodeorder = kodeorder + '+' + kodebox;
                    }
                    catch
                    { 
                    
                    }
                }

                
            User user = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", user.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

           

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", submenuordered.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {
                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(kodeorder);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == kodeorder)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(kodeorder);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else
            {
                Session["habis"] = true;
            }
                return Redirect(Request.UrlReferrer.ToString());      
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult CancelAllOrder()
        {
            Session.Abandon();
            return Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult CancelOne(string id)
        {
            ArrayList order = new ArrayList();
            order = (ArrayList)Session["order"];


           // int i = 0;
            order.RemoveAt(int.Parse(id));
           /* foreach (Temporder row in order)
            {
                if (row.kode == id)
                {
                    order.RemoveAt(i);
                    break;
                }
                i++;
            }
             */
            Session["order"] = order;
            return Redirect(Request.UrlReferrer.ToString() );
        }

        public ActionResult OrderSubmenu(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Logon", "Account");
            }

            User user = new userHelper().GetUser(User.Identity.Name);
            List<ICriterion> CritAddress = new List<ICriterion>();
            List<ICriterion> CritSubmenu = new List<ICriterion>();
            List<ICriterion> CritEmpty = new List<ICriterion>();

            CritAddress.Add(Restrictions.Eq("is_main", 1));
            CritAddress.Add(Restrictions.Eq("user.id", user.Id));
            Address alamat = new AddressService().FindByCriteria(CritAddress);

            CritSubmenu.Add(Restrictions.Eq("kode", id));
            Submenu tempsubmenu = new SubmenuService().FindByCriteria(CritSubmenu);

            CritEmpty.Add(Restrictions.Eq("outlet.Id", alamat.street.outlet.Id));
            CritEmpty.Add(Restrictions.Eq("submenu.Id", tempsubmenu.Id));

            Emptymenu emptymenu = new EmptymenuService().FindByCriteria(CritEmpty);

            if (emptymenu == null)
            {
                if (Session["order"] == null)//blm buat
                {
                    ArrayList order = new ArrayList();
                    Temporder item = new Temporder();
                    item.built(id);

                    order.Add(item);

                    Session["order"] = order;
                }
                else //udah buat 
                {
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    bool checker = false;

                    foreach (Temporder row in order)
                    {
                        if (row.kode == id)
                        {
                            row.add();
                            checker = true;
                            break;
                        }
                    }
                    if (checker == false)
                    {
                        Temporder item = new Temporder();
                        item.built(id);

                        order.Add(item);
                    }
                    Session["order"] = order;
                }
            }
            else 
            {
                Session["habis"] = true;
                
            }
             return Redirect(Request.UrlReferrer.ToString());
        }


        public ActionResult PickBox(int id)
        {
            IEnumerable<Box> model = new BoxService().FindAll();
            ViewBag.id = id;
            ViewBag.boxall = model;
            return View(model);
        }


        public ActionResult CheckEvent()
        {

            string result = null;
            List<ICriterion> Critevent = new List<ICriterion>();
            Critevent.Add(Restrictions.Eq("Id", 2));
            Critevent.Add(Restrictions.Eq("is_active", 1));

            Event eventcurrent = new EventService().FindByCriteria(Critevent);

            if (eventcurrent == null){
                result = null;
            }
            else {
                result = eventcurrent.name;
            }

            int pizzaid = Convert.ToInt16(Request.Form["pizzatype"]);
            if (pizzaid != 1 && pizzaid !=3) // original reguler
            {
                result = null;
            }
                       

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Changeqty() //bisa ngubah harga
        {

    
            ArrayList order = new ArrayList();
            order = (ArrayList)Session["order"];
            Hashtable tabel = new Hashtable();
            string  idpayment = Request.Form["idpayment"];

            int id = int.Parse(Request.Form["id"]);
            int qty = int.Parse(Request.Form["qty"]);
            Payment pembayaran;
            string kodesubmenu = "";
            Submenu submenu;
            int itemprice =0;
            int count = 0 ;
            int price = 0;
            int temp_diskon = 0;
            int diskon = 0;
            int delivery = int.Parse(new DataService().FindBy(2).value);
            int tax = 0;
 
            foreach (Temporder row in order)
            {
                bool check = false;
                int upgpastaprice = 0;
                if (count == id)
                {
                    row.quantity = qty;
                    check = true;
                }

                if (row.kode.Contains("+"))
                {
                    string[] temp = row.kode.Split('+');
                    string[] temp2 = temp[1].Split('-');
                    
                    kodesubmenu = temp[0];

                    List<ICriterion> Crit = new List<ICriterion>();
                    Crit.Add(Restrictions.Eq("kode", kodesubmenu));
                    submenu = new SubmenuService().FindByCriteria(Crit);

                    foreach (string mod in temp2)
                    {
                        List<ICriterion> critUpgPast = new List<ICriterion>();
                        critUpgPast.Add(Restrictions.Eq("kode", mod));
                        critUpgPast.Add(Restrictions.Eq("id_menu", submenu.menu.Id));
                        Upgradepasta upg = new UpgradepastaService().FindByCriteria(critUpgPast);

                        if (upg != null)
                        {
                            upgpastaprice = upg.price;
                            break;
                        } //kena upg pasta

                    }
                   
                }
                else
                {
                    kodesubmenu = row.kode;

                    List<ICriterion> Crit = new List<ICriterion>();
                    Crit.Add(Restrictions.Eq("kode", kodesubmenu));
                    submenu = new SubmenuService().FindByCriteria(Crit);
                }
            
                price = price + ((submenu.price_gross+upgpastaprice) * row.quantity);
                if (check == true)
                {
                    itemprice = (submenu.price_gross + upgpastaprice) * row.quantity;
                }

                if (idpayment != "")
                {
                    pembayaran = new PaymentService().FindBy(int.Parse(idpayment));

                    if (submenu.diskon == 1 && pembayaran.diskon > 0)
                    {

                        temp_diskon = temp_diskon + (((submenu.price_gross + upgpastaprice) * row.quantity * pembayaran.diskon) / 100);
                    }

                }
                count++;
            }

            if (idpayment != "")
            {
                int today = (int)DateTime.Now.DayOfWeek;

                 pembayaran = new PaymentService().FindBy(int.Parse(idpayment));

                string[] tempdiskonday = pembayaran.diskon_time.Split(';');


                tax = (((price - diskon) + delivery) * int.Parse(new DataService().FindBy(1).value)) / 100;

                int total = price - diskon + delivery + tax;

                if (total >= pembayaran.trigger_diskon && pembayaran.diskon > 0 && tempdiskonday[today] == "1")
                {
                    //diskon = (pembayaran.diskon * price) / 100;
                    diskon = temp_diskon;
                }
            }

            tabel["itemprice"] = String.Format("{0:0,0}", itemprice);
            tabel["price"] = price;
            tabel["diskon"] = diskon; 
            tabel["delivery"] = delivery;
            tax = (((price - diskon) + delivery) * int.Parse(new DataService().FindBy(1).value)) / 100;
            tabel["tax"] = tax;
            tabel["total"] = price-diskon+delivery+tax;

            tabel["pricetext"] = String.Format("{0:0,0}", price);
            tabel["diskontext"] = String.Format("{0:0,0}", diskon);
            tabel["deliverytext"] = String.Format("{0:0,0}", delivery);
            tabel["taxtext"] = String.Format("{0:0,0}", tax);
            tabel["totaltext"] = String.Format("{0:0,0}", price - diskon + delivery + tax);



            return Json(tabel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeVoucher() //bisa ngubah harga
        {


            ArrayList order = new ArrayList();
            order = (ArrayList)Session["order"];
            Hashtable tabel = new Hashtable();
            string idpayment = Request.Form["idpayment"];

            int val = int.Parse(Request.Form["val"]);
            Payment pembayaran;
            string kodesubmenu = "";
            Submenu submenu;
            int itemprice = 0;
            int count = 0;
            int price = 0;
            int temp_diskon = 0;
            int diskon = 0;
            int delivery = int.Parse(new DataService().FindBy(2).value);
            int tax = 0;

            foreach (Temporder row in order)
            {

                int upgpastaprice = 0;
                if (row.kode.Contains("+"))
                {
                    string[] temp = row.kode.Split('+');
                    
                    string[] temp2 = temp[1].Split('-');

                    kodesubmenu = temp[0];

                    List<ICriterion> Crit = new List<ICriterion>();
                    Crit.Add(Restrictions.Eq("kode", kodesubmenu));
                    submenu = new SubmenuService().FindByCriteria(Crit);
                    
                    foreach (string mod in temp2)
                    {
                        List<ICriterion> critUpgPast = new List<ICriterion>();
                        critUpgPast.Add(Restrictions.Eq("kode", mod));
                        critUpgPast.Add(Restrictions.Eq("id_menu", submenu.menu.Id));
                        Upgradepasta upg = new UpgradepastaService().FindByCriteria(critUpgPast);

                        if (upg != null)
                        {
                            upgpastaprice = upg.price;
                            break;
                        } //kena upg pasta

                    }

                    
                }
                else
                {

                    kodesubmenu = row.kode;

                    List<ICriterion> Crit = new List<ICriterion>();
                    Crit.Add(Restrictions.Eq("kode", kodesubmenu));
                    submenu = new SubmenuService().FindByCriteria(Crit);
                }
               
                price = price + ((submenu.price_gross + upgpastaprice) * row.quantity);

                if (idpayment != "")
                {
                    pembayaran = new PaymentService().FindBy(int.Parse(idpayment));

                    if (submenu.diskon == 1 && pembayaran.diskon > 0)
                    {

                        temp_diskon = temp_diskon + (((submenu.price_gross + upgpastaprice) * row.quantity * pembayaran.diskon) / 100);
                    }

                }
                count++;
            }

            if (idpayment != "")
            {
                int today = (int)DateTime.Now.DayOfWeek;

                pembayaran = new PaymentService().FindBy(int.Parse(idpayment));

                string[] tempdiskonday = pembayaran.diskon_time.Split(';');

                tax = (((price - diskon) + delivery) * int.Parse(new DataService().FindBy(1).value)) / 100;

                int total = price - diskon + delivery + tax;

                if (total >= pembayaran.trigger_diskon && pembayaran.diskon > 0 && tempdiskonday[today] == "1")
                {
                    //diskon = (pembayaran.diskon * price) / 100;
                    diskon = temp_diskon;
                }
            }

            diskon = diskon + val;

            tabel["itemprice"] = String.Format("{0:0,0}", itemprice);
            tabel["price"] = price;
            tabel["diskon"] = diskon;
            tabel["delivery"] = delivery;
            tax = (((price - diskon) + delivery) * int.Parse(new DataService().FindBy(1).value)) / 100;
            tabel["tax"] = tax < 0 ? 0 : tax;
            tabel["total"] = price - diskon + delivery + tax < 0 ? 0 : price - diskon + delivery + tax;

            tabel["pricetext"] = String.Format("{0:0,0}", price);
            tabel["diskontext"] = String.Format("{0:0,0}", diskon);
            tabel["deliverytext"] = String.Format("{0:0,0}", delivery);
            tabel["taxtext"] = String.Format("{0:0,0}", tax < 0 ? 0 : tax);
            tabel["totaltext"] = String.Format("{0:0,0}", price - diskon + delivery + tax < 0 ? 0 : price - diskon + delivery + tax);

            return Json(tabel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CheckModifier()
        {
            string kode_modifier = Request.Form["kode_modifier"];
            int id_menu = int.Parse(Request.Form["id_menu"]);
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Like("kode_web", '%'+kode_modifier+'%'));
            Crit.Add(Restrictions.Eq("menu.Id", id_menu));
            int total;
            IEnumerable<Submenu> Submenu = new SubmenuService().FindAllByCriteria(Crit, out total, 0, 100, "id", "ASC");

            Hashtable table = new Hashtable();
            int i = 0;
            foreach (Submenu row in Submenu)
            {
                table.Add(i.ToString(), row.kode_web);
                i++;
            }


            return Json(table, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ChangePayment()// bisa ngubah harga
        {

            Hashtable tabel = new Hashtable();
            int idpayment = int.Parse(Request.Form["idpayment"]);
            string kodesubmenu = "";
            Submenu submenu;
            int count = 0;
            int price = 0;
            int diskon = 0;
            int temp_diskon = 0;
            int delivery = 0;
            int tax = 0;

            if (Session["order"] != null && User.Identity.IsAuthenticated)
            {
                Payment pembayaran = new PaymentService().FindBy(idpayment);

                delivery = int.Parse(new DataService().FindBy(2).value);
                ArrayList order = new ArrayList();
                order = (ArrayList)Session["order"];
                foreach (Temporder row in order)
                {
                    int upgpastaprice = 0;

                    if (row.kode.Contains("+"))
                    {
                        string[] temp = row.kode.Split('+');
                        string[] temp2 = temp[1].Split('-');
                        
                        kodesubmenu = temp[0];

                        List<ICriterion> Crit = new List<ICriterion>();
                        Crit.Add(Restrictions.Eq("kode", kodesubmenu));
                        submenu = new SubmenuService().FindByCriteria(Crit);

                        foreach (string mod in temp2)
                        {
                            List<ICriterion> critUpgPast = new List<ICriterion>();
                            critUpgPast.Add(Restrictions.Eq("kode", mod));
                            critUpgPast.Add(Restrictions.Eq("id_menu", submenu.menu.Id));
                            Upgradepasta upg = new UpgradepastaService().FindByCriteria(critUpgPast);

                            if (upg != null)
                            {
                                upgpastaprice = upg.price;
                                break;
                            } //kena upg pasta
                        }
                    }
                    else
                    {
                        kodesubmenu = row.kode;

                        List<ICriterion> Crit = new List<ICriterion>();
                        Crit.Add(Restrictions.Eq("kode", kodesubmenu));
                        submenu = new SubmenuService().FindByCriteria(Crit);
                    }
                    price = price + ((submenu.price_gross + upgpastaprice) * row.quantity);

                    if (submenu.diskon == 1 && pembayaran.diskon > 0)
                    {
                        temp_diskon = temp_diskon + (((submenu.price_gross + upgpastaprice) * row.quantity * pembayaran.diskon) / 100);
                    }
                    count++;
                }

                int today = (int)DateTime.Now.DayOfWeek;

               

                string[] tempdiskonday = pembayaran.diskon_time.Split(';');


                tax = (((price - diskon) + delivery) * int.Parse(new DataService().FindBy(1).value)) / 100;

                int total = price - diskon + delivery + tax;

                if (total >= pembayaran.trigger_diskon && pembayaran.diskon > 0 && tempdiskonday[today] == "1")
                {
                   // diskon = (pembayaran.diskon * price) / 100;
                    diskon = temp_diskon;
                }
            }
            tabel["price"] = price;
            tabel["diskon"] = diskon;
            tabel["delivery"] = delivery;
            tax = (((price - diskon) + delivery) * int.Parse(new DataService().FindBy(1).value)) / 100;
            tabel["tax"] = tax;
            tabel["total"] = price - diskon + delivery + tax;

            
            tabel["pricetext"] = String.Format("{0:0,0}", price);
            tabel["diskontext"] = String.Format("{0:0,0}", diskon);
            tabel["deliverytext"] = String.Format("{0:0,0}", delivery);
            tabel["taxtext"] = String.Format("{0:0,0}", tax);
            tabel["totaltext"] = String.Format("{0:0,0}", price - diskon + delivery + tax);

            return Json(tabel, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Checkout(FormCollection form)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    RedirectToAction("Logon", "Account");
                }

                if (Session["order"] == null)//blm buat
                {
                    RedirectToAction("Index", "Menu");
                }
                else //udah buat 
                {

                    Ordercust ordercust = new Ordercust();
                    Statusorder status = new Statusorder();
       
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    string delivery_date = Request.Form["delivery_date"];
                    string delivery_time = Request.Form["delivery_time"];
                    string id_outlet = Request.Form["id_outlet"];
                    string format = "MM/dd/yyyy HH:mm";
                    DateTime deliveryfull = DateTime.ParseExact(delivery_date + " " + delivery_time, format,provider);
                    ordercust.delivery_time = deliveryfull;
                    
                    Payment payment = new PaymentService().FindBy(Convert.ToInt32(Request.Form["payment-type"]));
                    int typepayment = payment.type;
                    if (payment.type == 1)//status blm bayar online
                    {
                       status =  new StatusorderService().FindBy(1);//waiting for appointment
                    }
                    if (payment.type == 0)//cash langsung agent kudu validasi
                    {
                        status = new StatusorderService().FindBy(2);//waiting for validation
                    }

                    IEnumerable<Payment> paymentchild = new menuHelper().getPaymentChildren(payment.Id);

                    if (paymentchild.Count() != 0 && Request.Form["payment-child"]!="")
                    {
                         payment = new PaymentService().FindBy(Convert.ToInt32(Request.Form["payment-child"]));
                    }

                    User user = new userHelper().GetUser(User.Identity.Name);
                    Address address = new AddressService().FindBy(Convert.ToInt32(Request.Form["id-address"]));
                    Outlet outlet = new OutletService().FindBy(int.Parse(id_outlet));
                    Voucher voucher = null;
                    try
                    {
                         voucher = new VoucherService().FindBy(Convert.ToInt32(Request.Form["voucher"]));
                    }
                    catch 
                    {
                         voucher = null; 
                    }
                    ordercust.status = status;
                    ordercust.payment = payment;
                    ordercust.user = user;
                    ordercust.address = address;
                    ordercust.outlet = outlet;
                    if (voucher != null)
                    {
                        ordercust.voucher = voucher;
                    }
                    ordercust.price = int.Parse(Request.Form["price"]);
                    ordercust.total_price = int.Parse(Request.Form["total_price"]);
                    ordercust.delivery = int.Parse(Request.Form["delivery"]);
                    ordercust.tax = int.Parse(Request.Form["tax"]);
                    ordercust.diskon = int.Parse(Request.Form["diskon"]);

                    ordercust.created = DateTime.Now;
                    ordercust.Save();
                    ArrayList order = new ArrayList();
                    order = (ArrayList)Session["order"];

                    string kodesubmenu;
                    foreach (Temporder row in order)
                    {
                        string tail = "";
                        if (row.kode.Contains("+"))
                        {
                            string[] temp = row.kode.Split('+');

                            kodesubmenu = temp[0];
                            tail = temp[1];
                        }
                        else
                        {
                            kodesubmenu = row.kode;
                        }

                        Ordersubmenu ordersubmenu = new Ordersubmenu();
                        ordersubmenu.id_order = ordercust.Id;
                        ordersubmenu.tail = tail;
                        ordersubmenu.quantity = row.quantity;
                        List<ICriterion> Critsubmenuordered = new List<ICriterion>();
                        Critsubmenuordered.Add(Restrictions.Eq("kode", kodesubmenu));
                        Submenu submenuordered = new SubmenuService().FindByCriteria(Critsubmenuordered);

                        ordersubmenu.id_submenu = submenuordered.Id;
                        ordersubmenu.Save();
                    }
                    Session.Abandon();
                    if (typepayment == 1)//online payment
                    {
                        if (payment.Id == 8)//mandiri
                        {
                            return RedirectToAction("Mandiri", "transaction", new {idcust =ordercust.Id });
                        }
                        else//infinitium
                        {
                            return RedirectToAction("infinitium", "transaction", new { idcust = ordercust.Id });                        
                        }
                    }
                    return RedirectToAction("Index/"+ordercust.Id, "Trackorder");
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            catch 
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}
