using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Shop.Business.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
