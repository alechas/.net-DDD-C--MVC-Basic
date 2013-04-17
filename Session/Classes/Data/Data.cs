using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Data : EntityBase<int>, IAggregateRoot
    {
        public virtual string name { get; set; }
        public virtual string value { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
