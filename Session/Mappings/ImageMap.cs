using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            Map(x => x.url).Not.Nullable();
            Map(x => x.image).Not.Nullable();
            Map(x => x.type).Not.Nullable();
        }
    }
}
