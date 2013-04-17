using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PHD.Service.ModelService;
using PHD.Session.Classes;
using NHibernate.Criterion;

namespace PHD.MVC.Helper
{
    public class userHelper
    {
        public static UserService userv = new UserService();
        
        public User GetUser(string input)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("email", input));
            Crit.Add(Restrictions.Eq("status", 1));
            User User = userv.FindByCriteria(Crit);

            return User;
        }
        public string GetName(string input)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("email", input));
            Crit.Add(Restrictions.Eq("status", 1));
            User User = userv.FindByCriteria(Crit);

            return User.nama;
        } 

        public string GetRole(string input)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("email", input));
            Crit.Add(Restrictions.Eq("status", 1));
            User User = userv.FindByCriteria(Crit);
            return User.role.name;
        }

        public string GetProfPic(string input)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("email", input));
            Crit.Add(Restrictions.Eq("status", 1));
            User User = userv.FindByCriteria(Crit);
            if (User != null)
            {
                return User.profpic;
            }
            else 
            {
                return null;
            }
        }

    }
}