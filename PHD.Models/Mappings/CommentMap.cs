using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Models.Classes;

namespace TRIMS.Repository.Mappings
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            
            Id(x => x.Id).Column("id_comment");
            Map(x => x.comments).Not.Nullable();
            Map(x => x.date).Not.Nullable();
        }
    }
}
