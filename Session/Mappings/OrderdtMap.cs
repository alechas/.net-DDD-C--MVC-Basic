using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class OrderdtMap : ClassMap <Orderdt>
    {
        public OrderdtMap() {
            Id(x => x.Id).Column("id");
            Map(x => x.fcode).Not.Nullable();
            Map(x => x.seq).Not.Nullable();
            Map(x => x.subseq).Not.Nullable();
            Map(x => x.desc1).Not.Nullable();
            Map(x => x.qty).Not.Nullable();
            Map(x => x.unitprice).Not.Nullable();
            Map(x => x.t_able).Not.Nullable();
            Map(x => x.d_able).Not.Nullable();
            Map(x => x.fgroup).Not.Nullable();
            References<Orderhd>(x => x.Hd).Column("id_hd");
        }
    }
}
