using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;

public class Context : DbContext
{
    public Context() : base() { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=test.db");
        
    }

    public DbSet<Item> Inventory { get; set; }
}