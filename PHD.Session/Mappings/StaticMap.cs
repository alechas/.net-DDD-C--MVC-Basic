using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class StaticMap : ClassMap<Static>
    {
        public StaticMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            Map(x => x.url).Not.Nullable();
            Map(x => x.text).Not.Nullable();
            Map(x => x.position).Not.Nullable();
            References<Typestatic>(x => x.typestatic).Column("type");
        }
    }
}
