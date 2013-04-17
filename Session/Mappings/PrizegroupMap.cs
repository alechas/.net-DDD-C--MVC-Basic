using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class PrizegroupMap : ClassMap<Prizegroup>
    {
        public PrizegroupMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.description).Nullable();
            Map(x => x.kode).Nullable();
            Map(x => x.image).Not.Nullable();
        }
    }
}
