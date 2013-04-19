using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Session.Domain;

namespace Session.Classes
{
    public class Role : EntityBase<int>, IAggregateRoot
    {
       // public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string description { get; set; }

        public virtual IList<User> users { get; set; }
        // public virtual Role supplier { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
