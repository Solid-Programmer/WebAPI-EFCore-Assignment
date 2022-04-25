using Microsoft.EntityFrameworkCore;
using Project.DataAcessLayer.DataAccess.Entities;

namespace Project.DataAcessLayer.DataAccess
{
    public class SQLDbAppContext : DbContext
    {
        public SQLDbAppContext(DbContextOptions<SQLDbAppContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
