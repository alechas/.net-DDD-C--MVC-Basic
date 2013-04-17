using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            
            HasMany<Outlet>(x => x.outlets).KeyColumn("id_area").Inverse().Cascade.SaveUpdate().OrderBy("id ASC");
        }
    }
}
