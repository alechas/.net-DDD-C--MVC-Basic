using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Sitemenu : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual int position { get; set; }
        public virtual string url { get; set; }
        public virtual string image { get; set; }
        public virtual int type { get; set; }
        public virtual int status { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
