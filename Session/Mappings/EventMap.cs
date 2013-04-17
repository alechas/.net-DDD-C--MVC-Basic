using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.description).Nullable();
            Map(x => x.name).Nullable();
            Map(x => x.url).Nullable();
            Map(x => x.type).Nullable();
            Map(x => x.is_active).Nullable();
        }
    }
}
