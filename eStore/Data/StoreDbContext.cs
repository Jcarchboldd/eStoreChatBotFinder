using Microsoft.EntityFrameworkCore;

namespace eStore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Product> Products { get; set; }
    }
}