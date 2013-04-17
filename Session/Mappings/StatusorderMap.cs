using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class StatusorderMap : ClassMap<Statusorder>
    {
        public StatusorderMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.description).Not.Nullable();
            Map(x => x.name).Not.Nullable();
        }
    }
}
