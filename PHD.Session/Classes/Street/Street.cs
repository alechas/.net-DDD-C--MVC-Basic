using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Street : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string name_long { get; set; }
        public virtual int id_city { get; set; }
        public virtual int id_outlet { get; set; }
        public virtual int is_active { get; set; }
        public virtual Outlet outlet { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
