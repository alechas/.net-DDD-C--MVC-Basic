using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.description).Nullable();
            Map(x => x.nama).Not.Nullable();
            Map(x => x.kode).Nullable();
            Map(x => x.title).Not.Nullable();
            Map(x => x.status).Not.Nullable();
            Map(x => x.sequence).Not.Nullable();
            Map(x => x.id_typemenu).Not.Nullable();
            Map(x => x.image).Not.Nullable();
            Map(x => x.logourl).Nullable();
        }
    }
}
