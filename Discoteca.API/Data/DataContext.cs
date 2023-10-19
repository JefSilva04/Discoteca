using Microsoft.EntityFrameworkCore;
using Discoteca.Shared.Entities;

namespace Discoteca.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Attention> Attentions { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<ProductEvent> ProductEvents { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Event>().HasIndex(c => c.EventoId).IsUnique();
            //modelBuilder.Entity<ProductEvent>().HasKey(pe => new { pe.EventId, pe.ProductId });
            //modelBuilder.Entity<ProductEvent>().HasOne(pe => pe.Event).WithMany(e => e.ProductEvent).HasForeignKey(pe => pe.EventId);
            //modelBuilder.Entity<ProductEvent>().HasOne(pe => pe.Product).WithMany(p => p.ProductEvent).HasForeignKey(pe => pe.ProductId);
        }
    }
}
