using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Session.Classes;

namespace Session.Mappings
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {

            Id(x => x.Id).Column("id");

            Map(x => x.text).Nullable();
            References<User>(x => x.User).Column("id_user");
            References<Blog>(x => x.Blog).Column("id_blog");
        }
    }
}