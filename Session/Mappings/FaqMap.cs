using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class FaqMap : ClassMap<Faq>
    {
        public FaqMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.question).Not.Nullable();
            Map(x => x.answer).Not.Nullable();
            Map(x => x.status).Not.Nullable();
            Map(x => x.sequence).Not.Nullable();
        }
    }
}