using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product>? ProductItems { get; set; }
    }
}