using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class SaranMap : ClassMap<Saran>
    {
        public SaranMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.pesan).Not.Nullable();
            Map(x => x.email).Not.Nullable();
            Map(x => x.phone).Not.Nullable();
            Map(x => x.date).Not.Nullable();
            References<User>(x => x.user).Column("id_user");
        }
    }
}
