using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class UserreedemMap : ClassMap<Userreedem>
    {
        public UserreedemMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.prev_point).Nullable();
            Map(x => x.current_point).Nullable();
            Map(x => x.date_reedem).Nullable();
            References<User>(x => x.user).Column("id_user");
            References<Reedem>(x => x.reedem).Column("id_reedem");

        }
    }
}