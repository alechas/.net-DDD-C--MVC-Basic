using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Payment : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string description { get; set; }
        public virtual int type { get; set; }
        public virtual int status { get; set; }
        public virtual int bottom_limit { get; set; }
        public virtual int diskon { get; set; }
        public virtual int trigger_diskon { get; set; }
        public virtual string diskon_time { get; set; }
        public virtual int id_payment { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
