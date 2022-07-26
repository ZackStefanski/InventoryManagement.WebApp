//using NUnit.Framework;
using ClassDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
    

    [TestClass]
    public class ItemTests
    {
 
    //[TestMethod]
    //    public void GetItem_IsSuccess()
    //    {
    //        //Arrange - What variables will we need?
    //        var connectionStringBuilder =
    //            new SqliteConnectionStringBuilder { DataSource = ":memory:" };
    //        var connection = new SqliteConnection(connectionStringBuilder.ToString());
    //        var options = new DbContextOptionsBuilder<Context>()
    //                .UseSqlite()
    //                .Options;

    //    using (var context = new Context())
    //        {
    //            var 
    //        }
    //    //Act - What do we want our variables to do?
  

    //    //Assert - What should the result be?

    //    }
//    public void SqliteInMemoryBloggingControllerTest()
//    {
//        var connectionStringBuilder =
//                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
//        var connection = new SqliteConnection(connectionStringBuilder.ToString());
//        var options = new DbContextOptionsBuilder<Context>()
//                .UseSqlite()
//                .Options;

//        // Create the schema and seed some data
//        using var context = new ItemController(options);

//        if (context.Database.EnsureCreated())
//        {
//            using var viewCommand = context.Database.GetDbConnection().CreateCommand();
//            viewCommand.CommandText = @"
//CREATE VIEW AllResources AS
//SELECT Url
//FROM Blogs;";
//            viewCommand.ExecuteNonQuery();
//        }

//        context.AddRange(
//            new Blog { Name = "Blog1", Url = "http://blog1.com" },
//            new Blog { Name = "Blog2", Url = "http://blog2.com" });
//        context.SaveChanges();
//    }

//    BloggingContext CreateContext() => new BloggingContext(_contextOptions);

//    public void Dispose() => _connection.Dispose();
}

