using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Image : EntityBase<int>, IAggregateRoot
    {

        public virtual string name { get; set; }
        public virtual string url { get; set; }
        public virtual string image { get; set; }
        public virtual int type { get; set; }

        public virtual string getType()
        {
            if (this.type == 1)
            {
                return "Background Image";
            }
            else { return "Random Image"; }
        }
        public virtual void Bersih()
        {

        }

    }
}
