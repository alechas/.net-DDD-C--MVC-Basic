using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class OrdersubmenuMap : ClassMap<Ordersubmenu>
    {
        public OrdersubmenuMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.id_order).Not.Nullable();
            Map(x => x.id_submenu).Not.Nullable();
            Map(x => x.tail).Nullable();
            Map(x => x.quantity).Nullable();
        }
    }
}
