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

     


      

        public List<Object> IsMainAddress()
        {
            List<Object> list = new List<Object>();

            list.Add(new { value = 0, text = "Sekunder" });
            list.Add(new { value = 1, text = "Utama" });

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


       
      

      

       
    }
}