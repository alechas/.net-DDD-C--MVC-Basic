using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class UpgradeMap : ClassMap<Upgrade>
    {
        public UpgradeMap()
        {
            Id(x => x.Id).Column("id");
            Map(x => x.code).Not.Nullable();
            Map(x => x.name).Nullable();
            Map(x => x.kodejenis).Not.Nullable();
            Map(x => x.namajenis).Nullable();
            Map(x => x.kategori).Not.Nullable();
            Map(x => x.kode_modifier).Not.Nullable();

        }
    }
}