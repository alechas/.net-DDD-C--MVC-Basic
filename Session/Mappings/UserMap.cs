using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.username).Unique();
            Map(x => x.profpic).Nullable();
            Map(x => x.password).Not.Nullable();
            Map(x => x.nama).Not.Nullable();
            Map(x => x.hp).Nullable();
            Map(x => x.telepon).Nullable();
           
            Map(x => x.email).Unique();
            Map(x => x.status).Nullable();

            Map(x => x.tempat_lahir).Nullable();
            Map(x => x.jenis_kelamin).Nullable();

            // Map(x => x.profesi).Nullable();
            References<Profesi>(x => x.prof).Column("profesi");

            //Map(x => x.hobi).Nullable();
            References<Hobi>(x => x.hobirel).Column("hobi");


            Map(x => x.fav_hangout).Nullable();
            Map(x => x.fav_makanan).Nullable();
            Map(x => x.fav_lokasi).Nullable();
            Map(x => x.fav_brands).Nullable();
            Map(x => x.tanggal_lahir).Nullable();
            Map(x => x.register_date).Nullable();
            Map(x => x.point).Nullable();

            Map(x => x.first_time_logged).Nullable();

            References<Role>(x => x.role).Column("id_role");
            HasMany<Address>(x => x.Addresses).KeyColumn("id_user"); 
        }
    }
}