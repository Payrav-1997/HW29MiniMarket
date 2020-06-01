using Microsoft.EntityFrameworkCore;

namespace HW27_MiniMarket.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Adress> Adresses { get; set;}

        
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<ProductCategory>().HasData(
            new ProductCategory()
            {
                Id = 1,
                Category = "SSD"
            },
            new ProductCategory()
            {
                Id = 2,
                Category = "CPU"
            },
            new ProductCategory()
            {
                Id = 3,
                Category = "VGA"
            });
        }
    }
}