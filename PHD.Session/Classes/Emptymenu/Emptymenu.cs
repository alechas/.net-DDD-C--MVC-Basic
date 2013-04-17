using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Emptymenu: EntityBase<int>, IAggregateRoot
    {
        public virtual Submenu submenu { get; set; }
        public virtual Outlet outlet { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
