using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class DataMap : ClassMap<Data>
    {
        public DataMap()
        {

            Id(x => x.Id).Column("id");

            Map(x => x.name).Nullable();
            Map(x => x.value).Nullable();

        }
    }
}
