using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class User : EntityBase<int>, IAggregateRoot
    {

        public virtual string username { get; set; }
        public virtual string profpic { get; set; }
        public virtual string password { get; set; }
        public virtual string nama { get; set; }
        public virtual string email { get; set; }
        public virtual string hp { get; set; }
        public virtual string telepon { get; set; }

        public virtual string tempat_lahir { get; set; }
        public virtual string jenis_kelamin { get; set; }
        
        public virtual string profesi { get; set; }
      
        public virtual string hobi { get; set; }
      
        
        public virtual string fav_hangout { get; set; }
        public virtual string fav_makanan { get; set; }
        public virtual string fav_lokasi { get; set; }
        public virtual string fav_brands { get; set; }
        public virtual int point { get; set; }
        public virtual int first_time_logged { get; set; }
        public virtual DateTime tanggal_lahir { get; set; }
        public virtual DateTime register_date { get; set; }
        public virtual int status { get; set; }
        public virtual int id_role { get; set; }

        public virtual Role role { get; set; }
      
        public virtual void Bersih()
        {
            this.nama = String.IsNullOrEmpty(this.nama) ? " " : this.nama;
            this.fav_hangout = String.IsNullOrEmpty(this.fav_hangout) ? " " : this.fav_hangout;
            this.fav_brands = String.IsNullOrEmpty(this.fav_brands) ? " " : this.fav_brands;
            this.fav_lokasi = String.IsNullOrEmpty(this.fav_lokasi) ? " " : this.fav_lokasi;
            this.fav_makanan = String.IsNullOrEmpty(this.fav_makanan) ? " " : this.fav_makanan;
        }
    }
}
