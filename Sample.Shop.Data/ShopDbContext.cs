using Microsoft.EntityFrameworkCore;
using Sample.Shop.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Shop.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) 
            : base(options)
        {

        }
    }
}
