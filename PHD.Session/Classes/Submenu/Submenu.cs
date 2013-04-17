using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Submenu : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string description { get; set; }
        public virtual int price { get; set; }
        public virtual int price_gross { get; set; }
        public virtual int id_menu { get; set; }
        public virtual Menu menu { get; set; }

        public virtual int id_prizegroup { get; set; }
        public virtual Prizegroup prizegroup { get; set; }
        
        public virtual string image { get; set; }
        public virtual string text { get; set; }
        public virtual int diskon { get; set; }
        public virtual int status { get; set; }
        public virtual string kode { get; set; }
        public virtual string kode_web { get; set; }
        public virtual int point { get; set; }
        public virtual string kodejenis { get; set; }

        public virtual void Bersih()
        {

        }
    }
}
