using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class ConfigsMap : ClassMap<Configs>
    {
        public ConfigsMap() {
            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            Map(x => x.value).Not.Nullable();
            Map(x => x.description).Not.Nullable();
        }
    }
}
