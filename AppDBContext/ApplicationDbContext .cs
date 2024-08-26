using MicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroService.AppDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entity>().HasKey(e => e.Id);
        }
    }

}
