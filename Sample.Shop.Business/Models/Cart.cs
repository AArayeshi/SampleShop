using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Shop.Business.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int ItemsCount { get; set; }
        public DateTime CreateTime { get; set; }

        public User User { get; set; }
        public List<CartProduct> Products { get; set; }
    }
}
