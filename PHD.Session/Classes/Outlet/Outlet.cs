using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Outlet : EntityBase<int>, IAggregateRoot
    {
        public virtual int id { get; set; }
        public virtual string kode { get; set; }
        public virtual string name { get; set; }
        public virtual int id_area { get; set; }
        public virtual string map { get; set; }
        public virtual Area area { get; set; }
        public virtual string WorkingTimeSundayStart { get; set; }
        public virtual string WorkingTimeSundayEnd { get; set; }
        public virtual string WorkingTimeMondayStart { get; set; }
        public virtual string WorkingTimeMondayEnd { get; set; }
        public virtual string WorkingTimeTuesdayStart { get; set; }
        public virtual string WorkingTimeTuesdayEnd { get; set; }
        public virtual string WorkingTimeWednesdayStart { get; set; }
        public virtual string WorkingTimeWednesdayEnd { get; set; }
        public virtual string WorkingTimeThursdayStart { get; set; }
        public virtual string WorkingTimeThursdayEnd { get; set; }
        public virtual string WorkingTimeFridayStart { get; set; }
        public virtual string WorkingTimeFridayEnd { get; set; }
        public virtual string WorkingTimeSaturdayStart { get; set; }
        public virtual string WorkingTimeSaturdayEnd { get; set; }
        public virtual string DeliveryTimeSundayStart { get; set; }
        public virtual string DeliveryTimeSundayEnd { get; set; }
        public virtual string DeliveryTimeMondayStart { get; set; }
        public virtual string DeliveryTimeMondayEnd { get; set; }
        public virtual string DeliveryTimeTuesdayStart { get; set; }
        public virtual string DeliveryTimeTuesdayEnd { get; set; }
        public virtual string DeliveryTimeWednesdayStart { get; set; }
        public virtual string DeliveryTimeWednesdayEnd { get; set; }
        public virtual string DeliveryTimeThursdayStart { get; set; }
        public virtual string DeliveryTimeThursdayEnd { get; set; }
        public virtual string DeliveryTimeFridayStart { get; set; }
        public virtual string DeliveryTimeFridayEnd { get; set; }
        public virtual string DeliveryTimeSaturdayStart { get; set; }
        public virtual string DeliveryTimeSaturdayEnd { get; set; }
        public virtual string address { get; set; }
        public virtual IList<Street> Streets { get; set; }
        public virtual IList<Ordercust> Order { get; set; }
        public virtual IList<Orderhd> Orderhd { get; set; }

        public virtual int status { get; set; }
        public virtual Outlet outlet { get; set; }
        public virtual void Bersih()
        {

        }
    }
}
