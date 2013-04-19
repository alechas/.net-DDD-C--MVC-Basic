using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Temporder
    {
        public string kode;
        public int quantity;

        public void add()
        {
            this.quantity++;
        }

        public void min()
        {
            this.quantity--;
        
        }

        public void built(string kode)
        {
            this.kode = kode;
            this.quantity = 1;
            
        }


    }
}