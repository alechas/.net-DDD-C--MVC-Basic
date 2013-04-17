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
    public class menuHelper
    {

        public IEnumerable<Sitemenu> getHeadermenu()
        {
            List<Object> list = new List<Object>();
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("type", 0));
            int total;
            IEnumerable<Sitemenu> Sitemenu = new SitemenuService().FindAllByCriteria(Crit, out total, 0, 7, "position", "ASC");

            return Sitemenu;
      
        }

        public IEnumerable<Sitemenu> getFootermenu()
        {
            List<Object> list = new List<Object>();
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("status", 1));
            Crit.Add(Restrictions.Eq("type", 1));
            int total;
            IEnumerable<Sitemenu> Sitemenu = new SitemenuService().FindAllByCriteria(Crit, out total, 0, 7, "position", "ASC");
            return Sitemenu;
        }

        public IEnumerable<Sitemenu> getChildmenu()
        {
            List<Object> list = new List<Object>();
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("id_parent", 1));
            Crit.Add(Restrictions.Eq("type", 2));
            int total;
            IEnumerable<Sitemenu> Sitemenu = new SitemenuService().FindAllByCriteria(Crit, out total, 0, 5, "position", "ASC");
            return Sitemenu;
        }

        public IEnumerable<Image> getSlideImage()
        {
            List<Object> list = new List<Object>();
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("type", 1));
            int total;
            IEnumerable<Image> Image = new ImageService().FindAllByCriteria(Crit, out total, 0, 5, "id", "ASC");
            return Image;
        }

        public IEnumerable<Payment> getPaymenttype(int i)
        {

          
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("type", i));
            Crit.Add(Restrictions.Eq("status", 1));
            int total;
            IEnumerable<Payment> payment = new PaymentService().FindAllByCriteria(Crit, out total, 0, 5, "id", "ASC");
            return payment;
        
        }

        public IEnumerable<Payment> getPaymentChildren(int i)
        {
            List<ICriterion> Crit = new List<ICriterion>();

            Crit.Add(Restrictions.Eq("id_payment", i));
            Crit.Add(Restrictions.Eq("status", 1));

            int total;
            IEnumerable<Payment> payment = new PaymentService().FindAllByCriteria(Crit, out total, 0, 5, "id", "ASC");
            return payment;
        }

    }
}