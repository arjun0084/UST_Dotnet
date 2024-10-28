using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {
        }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Order>().HasKey(c => c.OrderId);
            modelBuilder.Entity<Product>().HasKey(c => c.ProductId);
        }
    }
}
