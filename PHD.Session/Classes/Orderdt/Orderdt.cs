using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Orderdt : EntityBase<int>, IAggregateRoot
    {
        public virtual string fcode { get; set; }
        public virtual int seq { get; set; }
        public virtual int subseq { get; set; }
        public virtual string desc1 { get; set; }
        public virtual int qty { get; set; }
        public virtual int unitprice { get; set; }
        public virtual string t_able { get; set; }
        public virtual string d_able { get; set; }
        public virtual string fgroup { get; set; }
        public virtual Orderhd Hd { get; set; }
        public virtual void Bersih(){
            this.desc1 = String.IsNullOrEmpty(this.desc1) ? " " : this.desc1;
            this.fgroup = String.IsNullOrEmpty(this.fgroup) ? " " : this.fgroup;
        }
    }
}
