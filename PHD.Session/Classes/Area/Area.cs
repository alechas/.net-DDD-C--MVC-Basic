using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Area : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }

        public virtual IList<Outlet> outlets { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
