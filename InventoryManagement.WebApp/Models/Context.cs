using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;
//using InventoryManagement.WebApp.Models;

public class Context : DbContext
{
    public Context() : base() { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=Inventory.db");
        
    }

    public DbSet<Item> Inventory { get; set; }

    //public DbSet<Item> Quote { get; set; }

}