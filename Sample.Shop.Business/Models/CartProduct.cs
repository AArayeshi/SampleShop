using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Shop.Business.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
