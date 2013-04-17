using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Criterion;
using PHD.Service.ModelService;
using PHD.Session.Classes;

namespace PHD.MVC.Helper
{
    public class Dropdown
    {

        public List<Object> TypeAddress()
        {
            List<Object> list = new List<Object>();
            TypeaddressService serv = new TypeaddressService();
            IEnumerable<Typeaddress> data = serv.FindAll();
            list.Add(new { value = "-1", text = "silahkan pilih" });
            foreach (var row in data)
            {
                list.Add(new { value = row.Id, text = row.name });
            }
            return list;
        }


        public List<Object> TypeAddressAdmin()
        {
            List<Object> list = new List<Object>();
            TypeaddressService serv = new TypeaddressService();
            IEnumerable<Typeaddress> data = serv.FindAll();
            foreach (var row in data)
            {
                list.Add(new { value = row.Id, text = row.name });
            }
            return list;
        }

        public List<Object> IsMainAddress()
        {
            List<Object> list = new List<Object>();

            list.Add(new { value = 0, text = "Sekunder" });
            list.Add(new { value = 1, text = "Utama" });

            return list;
        }


        public List<Object> getUserAddress(string name)
        {
            User model = new userHelper().GetUser(name);
            List<Object> list = new List<Object>();
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("user.Id", model.Id));
            Crit.Add(Restrictions.Eq("status", 1));
            int total;
            IEnumerable<Address> address = new AddressService().FindAllByCriteria(Crit, out total, 0, 10, "id", "asc");
            foreach (var row in address)
            {
                list.Add(new { value = row.Id, text = row.street.name });
            }
            return list;
        }

        public List<Object> Role()
        {
            List<Object> list = new List<Object>();
            RoleService servrole = new RoleService();
            IEnumerable<Role> data = servrole.FindAll();
            foreach(var row in data)     
            { 
               list.Add( new { value = row.Id , text = row.name  });   
            }
            return list;
        }

        public List<Object> Status()
        {
            List<Object> list = new List<Object>();
           
            list.Add(new { value = -1, text = "Tidak Aktif" });
            list.Add(new { value = 0, text = "Pending" });
            list.Add(new { value = 1, text = "Aktif" });
           
            return list;
        }

        public List<Object> StatusSubmenu()
        {
            List<Object> list = new List<Object>();

            list.Add(new { value = 0, text = "Tidak Aktif" });
            list.Add(new { value = 1, text = "Aktif" });
            
            return list;
        }

        public List<Object> cat_submenu()
        {
            List<Object> list = new List<Object>();

            list.Add(new { value = 0, text = "Tidak" });
            list.Add(new { value = 1, text = "Ya" });

            return list;
        }

        public List<Object> StatusFaq()
        {
            List<Object> list = new List<Object>();
            list.Add(new { value = 0, text = "Tidak Aktif" });
            list.Add(new { value = 1, text = "Aktif" });

            return list;
        }


        public List<Object> TypeStatic()
        {
            List<Object> list = new List<Object>();
            TypestaticService servrole = new TypestaticService();
            IEnumerable<Typestatic> data = servrole.FindAll();
            foreach (var row in data)
            {
                list.Add(new { value = row.Id, text = row.name });
            }
            return list;
        }

        public List<Object> GetMenu()
        {
            List<Object> list = new List<Object>();
            IEnumerable<Menu> data = new MenuService().FindAll();
            list.Add(new { value = "", text = "----------" });

            foreach (var row in data)
            {
                list.Add(new { value = row.Id, text = row.title });
            }
            return list;
        }

        public List<Object> GetTypeSubMenu()
        {
            List<Object> list = new List<Object>();
            IEnumerable<Typesubmenu> data = new TypesubmenuService().FindAll();

            foreach (var row in data)
            {
                list.Add(new { value = row.Id, text = row.name });
            }
            return list;
        }

        public List<Object> GetSubmenu()
        {
            List<Object> list = new List<Object>();
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            int total;
            IEnumerable<Submenu> submenu = new SubmenuService().FindAllByCriteria(Crit, out total, 0, 6, "Id", "ASC");

            list.Add(new { value = "", text = "----------" });

            foreach (var row in submenu)
            {
                list.Add(new { value = row.Id, text = row.name });
            }
            return list;
        }

    }
}