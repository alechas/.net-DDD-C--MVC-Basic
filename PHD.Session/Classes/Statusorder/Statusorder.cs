using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Statusorder : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string description { get; set; }
        public virtual void Bersih()
        {

        }

    }
}
