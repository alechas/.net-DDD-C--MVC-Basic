using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Session.Classes;

namespace Session.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            Map(x => x.description).Not.Nullable();

            HasMany<User>(x => x.users).KeyColumn("id_role").Inverse().Cascade.SaveUpdate().OrderBy("id ASC");
        }
    }
}