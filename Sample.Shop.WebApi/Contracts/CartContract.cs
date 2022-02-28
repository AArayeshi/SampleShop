using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Shop.WebApi.Contracts
{
    public class CartContract
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int ItemsCount { get; set; }
        public DateTime CreateTime { get; set; }

    }
}
