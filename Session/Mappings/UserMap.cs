using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.username).Unique();
           
            Map(x => x.password).Not.Nullable();
            Map(x => x.name).Not.Nullable();

            References<Role>(x => x.Role).Column("id_role");
        }
    }
}