using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Session.Domain;

namespace Session.Classes
{
    public class Comment : EntityBase<int>, IAggregateRoot
    {
        public virtual string text { get; set; }
        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual DateTime created { get; set; }

        public virtual void Bersih()
        { }

    }
}
