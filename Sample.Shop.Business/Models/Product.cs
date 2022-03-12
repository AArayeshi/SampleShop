using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Shop.Business.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
    }
}
