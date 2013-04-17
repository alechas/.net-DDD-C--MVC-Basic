using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using PHD.Session.Classes;

namespace PHD.Session.Mappings
{
    public class OrdercustMap : ClassMap<Ordercust>
    {
        public OrdercustMap()
        {

            Id(x => x.Id).Column("id");
            Map(x => x.kode).Nullable();
            Map(x => x.price).Not.Nullable();
            Map(x => x.diskon).Not.Nullable();
            Map(x => x.delivery).Not.Nullable();
            Map(x => x.tax).Not.Nullable();
            Map(x => x.total_price).Not.Nullable();
            Map(x => x.delivery_time).Not.Nullable();
            Map(x => x.created).Not.Nullable();
            Map(x => x.start_delivery_time).Nullable();
            Map(x => x.confirmed_time).Nullable();
            Map(x => x.cooking_time).Nullable();
            References<Statusorder>(x => x.status).Column("id_status");
            References<User>(x => x.user).Column("id_user");
            References<Payment>(x => x.payment).Column("id_payment");
            References<Address>(x => x.address).Column("id_address");
            References<Outlet>(x => x.outlet).Column("id_outlet");
            HasManyToMany<Submenu>(x => x.submenus).Table("Ordersubmenu").ParentKeyColumn("id_order").ChildKeyColumn("id_submenu");
            //References<Voucher>(x => x.voucher).Column("id_voucher");
        }
    }
}
