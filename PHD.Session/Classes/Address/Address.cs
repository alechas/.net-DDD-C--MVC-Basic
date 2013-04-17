using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Address : EntityBase<int>, IAggregateRoot
    {

        public virtual int id { get; set; }
        public virtual Street street { get; set; }

        public virtual string value { get; set; }
        public virtual User user { get; set; }
        public virtual Typeaddress typeaddress { get; set; }

        public virtual int is_main { get; set; }
        public virtual string blok { get; set; }
        public virtual string no_alamat { get; set; }
        public virtual string gedung { get; set; }
        public virtual string tempat { get; set; }
        public virtual string no_tempat { get; set; }
        public virtual string lantai { get; set; }
        public virtual string no_lantai { get; set; }
        public virtual string perusahaan { get; set; }
        public virtual string ket { get; set; }
        public virtual int status { get; set; }
        public virtual void Bersih()
        {

        }
      
     
    }
}
