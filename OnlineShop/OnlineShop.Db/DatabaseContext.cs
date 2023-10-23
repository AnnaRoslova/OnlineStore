using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
