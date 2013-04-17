using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Event : EntityBase<int>, IAggregateRoot
    {
        public virtual string name { get; set; }
        public virtual string description { get; set; }
        public virtual string url { get; set; }
        public virtual int type { get; set; }
        public virtual int is_active { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
