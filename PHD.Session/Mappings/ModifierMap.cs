using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class ModifierMap : ClassMap<Modifier>
    {
        public ModifierMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.name).Not.Nullable();
            Map(x => x.kode).Not.Nullable();
            Map(x => x.position).Not.Nullable();
            Map(x => x.sequence).Not.Nullable();
            Map(x => x.image).Not.Nullable();
            Map(x => x.status).Not.Nullable();
            Map(x => x.text).Not.Nullable();
            Map(x => x.htmlclass).Nullable();
            Map(x => x.htmlliprop).Nullable();
            Map(x => x.htmlhidvalue).Nullable();
            Map(x => x.htmlidref).Nullable();
            References<Menu>(x => x.menu).Column("id_menu");
            References<Modifier>(x => x.modifier).Column("id_modifier");

        }
    }
}