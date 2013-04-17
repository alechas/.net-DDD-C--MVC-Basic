using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class StreetMap : ClassMap<Street>
    {
        public StreetMap()
        {
            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            Map(x => x.name_long).Not.Nullable();
            Map(x => x.is_active).Nullable();
            References<Outlet>(x => x.outlet).Column("id_outlet");
        }
    }
}
