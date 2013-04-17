using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class OutletMap : ClassMap<Outlet>
    {
        public OutletMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.kode).Not.Nullable();
            Map(x => x.name).Not.Nullable();
            Map(x => x.address).Not.Nullable();
            Map(x => x.map).Nullable();
            Map(x => x.status).Nullable();

            Map(x => x.WorkingTimeSundayStart).Not.Nullable();
            Map(x => x.WorkingTimeSundayEnd).Not.Nullable();
            Map(x => x.WorkingTimeMondayStart).Not.Nullable();
            Map(x => x.WorkingTimeMondayEnd).Not.Nullable();
            Map(x => x.WorkingTimeTuesdayStart).Not.Nullable();
            Map(x => x.WorkingTimeTuesdayEnd).Not.Nullable();
            Map(x => x.WorkingTimeWednesdayStart).Not.Nullable();
            Map(x => x.WorkingTimeWednesdayEnd).Not.Nullable();
            Map(x => x.WorkingTimeThursdayStart).Not.Nullable();
            Map(x => x.WorkingTimeThursdayEnd).Not.Nullable();
            Map(x => x.WorkingTimeFridayStart).Not.Nullable();
            Map(x => x.WorkingTimeFridayEnd).Not.Nullable();
            Map(x => x.WorkingTimeSaturdayStart).Not.Nullable();
            Map(x => x.WorkingTimeSaturdayEnd).Not.Nullable();


            Map(x => x.DeliveryTimeSundayStart).Not.Nullable();
            Map(x => x.DeliveryTimeSundayEnd).Not.Nullable();
            Map(x => x.DeliveryTimeMondayStart).Not.Nullable();
            Map(x => x.DeliveryTimeMondayEnd).Not.Nullable();
            Map(x => x.DeliveryTimeTuesdayStart).Not.Nullable();
            Map(x => x.DeliveryTimeTuesdayEnd).Not.Nullable();
            Map(x => x.DeliveryTimeWednesdayStart).Not.Nullable();
            Map(x => x.DeliveryTimeWednesdayEnd).Not.Nullable();
            Map(x => x.DeliveryTimeThursdayStart).Not.Nullable();
            Map(x => x.DeliveryTimeThursdayEnd).Not.Nullable();
            Map(x => x.DeliveryTimeFridayStart).Not.Nullable();
            Map(x => x.DeliveryTimeFridayEnd).Not.Nullable();
            Map(x => x.DeliveryTimeSaturdayStart).Not.Nullable();
            Map(x => x.DeliveryTimeSaturdayEnd).Not.Nullable();
        
            References<Area>(x => x.area).Column("id_area");
            References<Outlet>(x => x.outlet).Column("id_outlet");
            HasMany<Street>(x => x.Streets).KeyColumn("id_outlet");
            HasMany<Ordercust>(x => x.Order).KeyColumn("id_outlet");
            HasMany<Orderhd>(x => x.Orderhd).KeyColumn("shopcode");
        }
    }
}
