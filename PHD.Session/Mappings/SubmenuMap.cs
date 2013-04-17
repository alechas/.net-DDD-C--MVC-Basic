using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class SubmenuMap : ClassMap<Submenu>
    {
        public SubmenuMap()
        {
            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            Map(x => x.description).Nullable();
            Map(x => x.price).Not.Nullable();
            Map(x => x.image).Nullable();
            Map(x => x.text).Nullable();
            Map(x => x.status).Not.Nullable();
            Map(x => x.diskon).Nullable();
            Map(x => x.kode).Not.Nullable();
            Map(x => x.kode_web).Not.Nullable();
            Map(x => x.point).Nullable();
            Map(x => x.price_gross).Nullable();
            Map(x => x.kodejenis).Nullable();
            References<Menu>(x => x.menu).Column("id_menu");
            References<Prizegroup>(x => x.prizegroup).Column("id_prizegroup");
        }
    }
}