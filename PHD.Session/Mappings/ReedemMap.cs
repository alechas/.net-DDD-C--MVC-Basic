using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class ReedemMap : ClassMap<Reedem>
    {
        public ReedemMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.item).Nullable();
            Map(x => x.kode).Nullable();
            Map(x => x.image).Nullable();
            Map(x => x.point).Not.Nullable();
            Map(x => x.status).Not.Nullable();

        }
    }
}