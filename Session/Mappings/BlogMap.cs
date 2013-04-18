using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class BlogMap : ClassMap<Blog>
    {
        public BlogMap()
        {
            Id(x => x.Id).Column("id");

            Map(x => x.header).Not.Nullable();
            Map(x => x.text).Not.Nullable();
            Map(x => x.header).Nullable();
            Map(x => x.created).Not.Nullable();
            References<User>(x => x.createdBy).Column("created_by");
            HasMany<Comment>(x => x.Comments).KeyColumn("id_blog"); 
        }
    }
}
