using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;
using InventoryManagement.WebApp.Models;
//using InventoryManagement.WebApp.Models;

public class Context : DbContext
{
    public Context() : base() { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=Inventory.db");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuoteItem>().HasKey(s => new { s.ItemId, s.QuoteId });
    }

    public DbSet<Item> Inventory { get; set; }
    public DbSet<Quote> Quotes { get; set; }

}