using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Upgrade : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string code { get; set; }
        public virtual string name { get; set; }
        public virtual string kodejenis { get; set; }
        public virtual string namajenis { get; set; }
        public virtual string kategori { get; set; }
        public virtual string kode_modifier { get; set; }

        public virtual void Bersih()
        {

        }
    }
}
