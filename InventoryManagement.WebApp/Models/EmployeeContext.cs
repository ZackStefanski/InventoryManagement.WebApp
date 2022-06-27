using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;
using InventoryManagement.WebApp.Models;

public class EmployeeContext : DbContext
{
    public EmployeeContext() : base() { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=Employees.db");
        
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Item>()
    //        .Property(b => b.CreatedDate)
    //        .ValueGeneratedOnAdd();
    //}

    public DbSet<Employee> Employees { get; set; }
}