using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Session.Domain
{
    public class EntityBaseMap : ClassMap<EntityBase<int>>
    {
        public EntityBaseMap() {
            Id(x => x.Id);
        }
    }
}
