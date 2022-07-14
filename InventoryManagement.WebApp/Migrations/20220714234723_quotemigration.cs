using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.WebApp.Migrations
{
    public partial class quotemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}
