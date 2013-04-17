using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Ordersubmenu : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual int id_order { get; set; }
        public virtual int id_submenu { get; set; }
        public virtual int quantity { get; set; }
        public virtual string tail { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
