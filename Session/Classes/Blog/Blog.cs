using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Blog : EntityBase<int>, IAggregateRoot
    {
        public virtual string header { get; set; }
        public virtual string text { get; set; }
        public virtual DateTime created { get; set; }
        public virtual User createdBy { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
