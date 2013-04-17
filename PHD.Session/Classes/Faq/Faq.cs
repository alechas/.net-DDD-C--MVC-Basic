using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Faq : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string question { get; set; }
        public virtual string answer { get; set; }
        public virtual int status { get; set; }
        public virtual string sequence { get; set; }

        public virtual string getStatus()
        {
            if (this.status == 0)
            {
                return "Tidak Aktif";
            }
            else { return "Aktif"; }
        }
        public virtual void Bersih()
        {

        }
       
    }
}
