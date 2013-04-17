using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class PaymentMap : ClassMap<Payment>
    {
        public PaymentMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.description).Not.Nullable();
            Map(x => x.name).Not.Nullable();
            Map(x => x.type).Not.Nullable();
            Map(x => x.status).Nullable();
            Map(x => x.bottom_limit).Nullable();
            Map(x => x.trigger_diskon).Nullable();
            Map(x => x.diskon_time).Nullable();
            Map(x => x.diskon).Nullable();
            Map(x => x.id_payment).Nullable();
        }
    }
}
