using Microsoft.EntityFrameworkCore;
using MySqlConnector.Models;

namespace MySqlConnector;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Book { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=sg2plzcpnl486126.prod.sin2.secureserver.net;database=RoleRightApp;user=shanechen;password=123456789");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.ISBN);
            entity.Property(e => e.Title).IsRequired();
            entity.HasOne(d => d.Publisher)
                .WithMany(p => p.Books);
        });
    }
}