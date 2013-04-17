using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Prizegroup : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual int kode { get; set; }
        public virtual string description { get; set; }
        public virtual string image { get; set; }

        public virtual IList<Submenu> submenus { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
