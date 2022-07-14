using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;
//using InventoryManagement.WebApp.Models;

public class QuoteContext : DbContext
{
    public QuoteContext() : base() { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=Quote.db");
    }
    public DbSet<Item> Quote { get; set; }

}