using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.DBContext
{
    public class MainDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public MainDBContext(DbContextOptions<MainDBContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}
