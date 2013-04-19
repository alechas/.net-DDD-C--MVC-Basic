using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Session.Domain;

namespace Session.Classes
{
    public class User : EntityBase<int>, IAggregateRoot
    {

        public virtual string username { get; set; }
        public virtual string password { get; set; }
        public virtual string name { get; set; }
        public virtual Role Role { get; set; }
      
      
        public virtual void Bersih()
        {
   
        }
    }
}
