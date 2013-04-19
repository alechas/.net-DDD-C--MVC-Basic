using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcPaging;

using NHibernate.Criterion;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using Service.Validation;
using Service.ModelService;
using Session.Classes;

namespace MVC.Provider
{
    public class HibernateRoleProvider : RoleProvider
    {
        private RoleService _Role;
        private UserService _User;
        public HibernateRoleProvider() {
            _Role = new RoleService(new ModelStateWrapper(new ModelStateDictionary()));
            _User = new UserService(new ModelStateWrapper(new ModelStateDictionary()));
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            Role Role = new Role();
            Role.name = roleName;
            Role.description = "";
            Role.Save();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("name", roleName));
            
            Role Role = _Role.FindByCriteria(Crit);
            try
            {
                Role.Delete();
            }
            catch{
                return false;
            }
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("name", roleName));

            Role Role = _Role.FindByCriteria(Crit);
            IEnumerable<User> Users = Role.users;
            string[] names=new string[Users.Count()];
            int i = 0;
            
            foreach (User User in Users) { 
                names[i] = User.username;
                i++;
            }
            return names;
        }

        public override string[] GetAllRoles()
        {
            IEnumerable<Role> Roles =  _Role.FindAll();
            string[] names = new string[Roles.Count()];
            int i = 0;

            foreach (Role Role in Roles)
            {
                names[i] = Role.name;
                i++;
            }
            return names;
        }

        public override string[] GetRolesForUser(string username)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("name", username));

            //_User.FindByCriteria
            User Users = _User.FindByCriteria(Crit);
            string[] names = new string[1];
            names[1] = Users.Role.name;
            return names;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("name", roleName));

            Role Role = _Role.FindByCriteria(Crit);
            IEnumerable<User> Users = Role.users;
            string[] names = new string[Users.Count()];
            int i = 0;

            foreach (User User in Users)
            {
                names[i] = User.username;
                i++;
            }
            return names;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("name", roleName));

            Role Role = _Role.FindByCriteria(Crit);
            
            
            IEnumerable<User> Users = Role.users.Where(x=>x.username == username);
            if (Users.Count() == 0) {
                return false;
            }else {
                return true;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            int total;
            List<ICriterion> Crit = new List<ICriterion>();
            foreach (string username in usernames)
            {
                
                
                Crit.Add(Restrictions.Disjunction().Add(Restrictions.Eq("name", username)));
               
            }
            IEnumerable<User> Users = _User.FindAllByCriteria(Crit, out total, Convert.ToInt32(0), Convert.ToInt32(0), "username", "asc");
            foreach (User User in Users)
            {
                foreach (string rolename in roleNames) {
                    User.Role = null;
                    User.Save();
                }
               
            }
        }

        public override bool RoleExists(string roleName)
        {
            List<ICriterion> Crit = new List<ICriterion>();
            Crit.Add(Restrictions.Eq("name", roleName));

            Role Role = _Role.FindByCriteria(Crit);
            if (Role != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}