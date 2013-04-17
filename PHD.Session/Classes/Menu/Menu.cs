using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PHD.Session.Domain;

namespace PHD.Session.Classes
{
    public class Menu : EntityBase<int>, IAggregateRoot
    {
        public virtual string nama { get; set; }
        public virtual string description { get; set; }
        public virtual string kode { get; set; }
        public virtual string title { get; set; }
        public virtual int status { get; set; }
        public virtual int sequence { get; set; }
        public virtual string image { get; set; }
        public virtual string logourl { get; set; }

        public virtual Typemenu type { get; set; }
        public virtual int id_typemenu { get; set; }

        public virtual IList<Modifier> modifiers { get; set; }
        public virtual IList<Submenu> submenus { get; set; }

        public virtual void Bersih () {
            this.nama = String.IsNullOrEmpty(this.nama) ? " " : this.nama;
            this.description = String.IsNullOrEmpty(this.description) ? " " : this.description;
            this.kode = String.IsNullOrEmpty(this.kode) ? " " : this.kode;
            this.title = String.IsNullOrEmpty(this.title) ? " " : this.title;
            this.status = this.status <= 0 ? 0 : this.status;
            this.sequence = this.sequence <= 0 ? 0 : this.sequence;
            this.image = String.IsNullOrEmpty(this.image) ? "" : this.image;
            
        }
    }
}
