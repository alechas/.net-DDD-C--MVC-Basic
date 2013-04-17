using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PHD.Models.Classes;
using PHD.Session.Domain;

namespace PHD.Models.Classes
{
    public class Comment : EntityBase<int>, IAggregateRoot
    {
        
       
        public virtual string comments { get; set; }
        public virtual DateTime? date { get; set; }
        
    }
}
