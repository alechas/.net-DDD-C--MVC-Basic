using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Upgradepasta : EntityBase<int>, IAggregateRoot
    {
        public virtual string kode { get; set; }
        public virtual int id_menu { get; set; }
        public virtual string code_change { get; set; }
        public virtual int price { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
