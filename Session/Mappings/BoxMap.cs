using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class BoxMap : ClassMap<Box>
    {
        public BoxMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.description).Nullable();
            Map(x => x.nama).Nullable();
            Map(x => x.kode).Nullable();
            Map(x => x.type).Nullable();
            Map(x => x.image).Nullable();
            Map(x => x.sequence).Nullable();
        }
    }
}
