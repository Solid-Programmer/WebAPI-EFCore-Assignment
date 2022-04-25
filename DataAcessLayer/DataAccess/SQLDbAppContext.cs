using DataAcessLayer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer.DataAccess
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
