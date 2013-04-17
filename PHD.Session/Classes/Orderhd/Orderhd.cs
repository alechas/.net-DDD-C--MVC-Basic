using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Orderhd : EntityBase<int>, IAggregateRoot
    {
       
        public virtual string shopcode { get; set; }
       // public virtual string id_order { get; set; }
        public virtual int amount { get; set; }
        public virtual int biaya_kirim { get; set; }
        public virtual string date_trans { get; set; }
        public virtual string time_trans { get; set; }
        public virtual string date_deliver { get; set; }
        public virtual string time_deliver { get; set; }
        public virtual string customer { get; set; }
        public virtual string cashier { get; set; }
        public virtual string subdata1 { get; set; }
        public virtual string email { get; set; }
        public virtual string note { get; set; }
        public virtual string zone { get; set; }
        public virtual string zone_address { get; set; }
        public virtual string zone_remark { get; set; }
        public virtual string zone_district { get; set; }
        public virtual string zone_city { get; set; }
        public virtual string status_data { get; set; }
        public virtual int promise_time { get; set; }
        public virtual string segment { get; set; }
        public virtual DateTime? lup { get; set; }
        public virtual IList<Orderdt> orderdts { get; set; }
        public virtual Payment payment_type { get; set; }
        public virtual Ordercust order { get; set; }
        public virtual void Bersih()
        {

             /* public virtual int amount { get; set; }
        public virtual int biaya_kirim { get; set; }
        public virtual string date_trans { get; set; }
        public virtual string time_trans { get; set; }
        public virtual string date_deliver { get; set; }
        public virtual string time_deliver { get; set; }
        public virtual string customer { get; set; }
        public virtual string cashier { get; set; }
        public virtual string subdata1 { get; set; }
        public virtual string email { get; set; }
        public virtual string note { get; set; }
        public virtual string zone { get; set; }
        public virtual string zone_address { get; set; }
        public virtual string zone_remark { get; set; }
        public virtual string zone_district { get; set; }
        public virtual string zone_city { get; set; }
        public virtual string status_data { get; set; }
        public virtual int promise_time { get; set; }
        public virtual string segment { get; set; }*/
            this.subdata1 = String.IsNullOrEmpty(this.subdata1) ? " " : this.subdata1;

        }
    }
}
