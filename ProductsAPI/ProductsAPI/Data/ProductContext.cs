using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Data
    
{
    public class ProductContext : DbContext
            
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "Electronics items"
            },
            new Category
            {
                Id = 2,
                Name = "Cloths",
                Description = "Kapde"
            },
            new Category
            {
                Id = 3,
                Name = "Groceries",
                Description = "kirana"
            }
                );
        }


    }
}
