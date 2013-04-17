using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.is_main).Not.Nullable();
            References<User>(x => x.user).Column("id_user");
            References<Typeaddress>(x => x.typeaddress).Column("id_type_address");
            References<Street>(x => x.street).Column("id_street");
            Map(x => x.blok).Nullable();
            Map(x => x.no_alamat).Nullable();
            Map(x => x.gedung).Nullable();
            Map(x => x.tempat).Nullable();
            Map(x => x.no_tempat).Nullable();
            Map(x => x.lantai).Nullable();
            Map(x => x.ket).Nullable();
            Map(x => x.no_lantai).Nullable();
            Map(x => x.perusahaan).Nullable();
            Map(x => x.status).Nullable();
            
        }
    }
}
