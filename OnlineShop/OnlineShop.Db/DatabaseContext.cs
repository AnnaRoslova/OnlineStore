using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
