using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Ordercust : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string kode { get; set; }
        public virtual int total_price { get; set; }
        public virtual int price { get; set; }
        public virtual int diskon { get; set; }
        public virtual int delivery { get; set; }
        public virtual int tax { get; set; }

        public virtual int id_user { get; set; }
        public virtual int id_status { get; set; }
        public virtual int id_payment { get; set; }
        public virtual int id_address { get; set; }
        public virtual string confirmed_time { get; set; }
        public virtual string cooking_time { get; set; }
        public virtual string start_delivery_time { get; set; }

        public virtual Statusorder status { get; set; }
        public virtual User user { get; set; }
        public virtual Outlet outlet { get; set; }
        public virtual Payment payment { get; set; }
        public virtual Address address { get; set; }
        public virtual Voucher voucher { get; set; }
        public virtual DateTime delivery_time { get; set; }
        public virtual DateTime created { get; set; }
        public virtual IList<Submenu> submenus { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
