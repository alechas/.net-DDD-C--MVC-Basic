using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Box : EntityBase<int>, IAggregateRoot
    {
        public virtual string nama { get; set; }
        public virtual string description { get; set; }
        public virtual string kode { get; set; }
        public virtual int type { get; set; }
        public virtual string image { get; set; }
        public virtual string sequence { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
