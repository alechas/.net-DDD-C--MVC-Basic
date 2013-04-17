using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Reedem : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string item { get; set; }
        public virtual string kode{ get; set; }
        public virtual string image { get; set; }
        public virtual int point { get; set; }
        public virtual int status { get; set; }
        public virtual void Bersih()
        {

        }

    }
}
