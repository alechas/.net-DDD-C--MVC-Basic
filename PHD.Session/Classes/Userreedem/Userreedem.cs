using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Userreedem : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }

        public virtual int id_user { get; set; }
        public virtual User user { get; set; }

        public virtual int id_reedem { get; set; }
        public virtual Reedem reedem { get; set; }

        public virtual int prev_point { get; set; }
        public virtual int current_point { get; set; }
        public virtual DateTime date_reedem { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
