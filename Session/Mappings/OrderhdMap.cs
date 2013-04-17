using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class OrderhdMap:ClassMap<Orderhd>
    {
        public OrderhdMap()
        {
            Id(x => x.Id).Column("id");
           
            Map(x => x.shopcode).Not.Nullable();
            Map(x => x.amount).Not.Nullable();
            Map(x => x.biaya_kirim).Not.Nullable();
            Map(x => x.date_trans).Not.Nullable();
            Map(x => x.time_trans).Not.Nullable();
            Map(x => x.date_deliver).Not.Nullable();
            Map(x => x.time_deliver).Not.Nullable();
            Map(x => x.customer).Not.Nullable();
            Map(x => x.cashier).Nullable();
            Map(x => x.subdata1).Nullable();
            Map(x => x.email).Nullable();
            Map(x => x.note).Nullable();

            Map(x => x.zone).Not.Nullable();
            Map(x => x.zone_address).Not.Nullable();
            Map(x => x.zone_remark).Not.Nullable();
            Map(x => x.zone_district).Not.Nullable();
            Map(x => x.zone_city).Not.Nullable();
            Map(x => x.status_data).Not.Nullable();
            Map(x => x.promise_time).Not.Nullable();
            Map(x => x.segment).Not.Nullable();
            Map(x => x.lup).Nullable();
            HasMany<Orderdt>(x => x.orderdts).KeyColumn("id_hd");
            References<Payment>(x => x.payment_type).Column("payment_type");
            References<Ordercust>(x => x.order).Column("id_order");
        }
    }
}
