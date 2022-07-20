using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassDemo.Migrations
{
    public partial class TestMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Inventory",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Inventory",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "Inventory",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RetailPrice",
                table: "Inventory",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Inventory",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuoteItem",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItem", x => new { x.ItemId, x.QuoteId });
                    table.ForeignKey(
                        name: "FK_QuoteItem_Inventory_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteItem_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_QuoteId",
                table: "Inventory",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItem_QuoteId",
                table: "QuoteItem",
                column: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Quotes_QuoteId",
                table: "Inventory",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Quotes_QuoteId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "QuoteItem");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_QuoteId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "RetailPrice",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Inventory");
        }
    }
}
