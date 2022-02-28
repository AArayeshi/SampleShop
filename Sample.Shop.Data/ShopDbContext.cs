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
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Cart>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<CartProduct>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasMany(user => user.Carts).WithOne(cart => cart.User);

            modelBuilder.Entity<Cart>()
                .HasMany(cart => cart.Products).WithOne(product => product.Cart);

            
        }

    }
}
