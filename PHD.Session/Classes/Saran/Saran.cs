using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Saran : EntityBase<int>, IAggregateRoot
    {
        // public virtual int id { get; set; }
        public virtual string email { get; set; }
        public virtual string pesan { get; set; }
        public virtual string phone { get; set; }
        public virtual User user { get; set; }
        public virtual DateTime date { get; set; }
        // public virtual Role supplier { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
