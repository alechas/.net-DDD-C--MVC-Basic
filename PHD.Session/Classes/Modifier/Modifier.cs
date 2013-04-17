using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Modifier : EntityBase<int>, IAggregateRoot
    {
        public virtual string name { get; set; }
        public virtual string kode { get; set; }
        public virtual int position { get; set; }
        public virtual int status { get; set; }
        public virtual int sequence { get; set; }
        public virtual string image { get; set; }
        public virtual string text { get; set; }
        public virtual string htmlclass { get; set; }
        public virtual string htmlliprop { get; set; }
        public virtual string htmlhidvalue { get; set; }
        public virtual string htmlidref { get; set; }

        public virtual Menu menu { get; set; }
        public virtual int id_menu { get; set; }

        public virtual Modifier modifier { get; set; }
        public virtual int id_modifier { get; set; }
        public virtual void Bersih()
        {

        }

    }
}
