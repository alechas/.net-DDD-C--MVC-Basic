using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.ModelService;
using Session.Classes;
using NHibernate.Criterion;

namespace MVC.Helper
{
    public class userHelper
    {
        public static UserService userv = new UserService();

        public User GetUser(string input)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add( Restrictions.Eq("username", input));
            User User = userv.FindByCriteria(Crit);

            return User;
        }
    }
}