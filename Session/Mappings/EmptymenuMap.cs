using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class EmptymenuMap : ClassMap<Emptymenu>
    {
        public EmptymenuMap()
        {
            Id(x => x.Id).Column("id");
    
            References<Outlet>(x => x.outlet).Column("id_outlet");
            References<Submenu>(x => x.submenu).Column("id_submenu");
        }
    }
}