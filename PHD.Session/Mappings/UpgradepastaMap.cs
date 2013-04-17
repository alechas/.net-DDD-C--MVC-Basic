using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class UpgradepastaMap : ClassMap<Upgradepasta>
    {
        public UpgradepastaMap()
        {
            Id(x => x.Id).Column("id");
            Map(x => x.kode).Not.Nullable();
            Map(x => x.id_menu).Not.Nullable();
            Map(x => x.price).Not.Nullable();
            Map(x => x.code_change).Not.Nullable();
        }
    }
}
