using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInventory");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "ticket");

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_InventoryId",
                table: "books",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_inventory_InventoryId",
                table: "books",
                column: "InventoryId",
                principalTable: "inventory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_inventory_InventoryId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_InventoryId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "books");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BookInventory",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    inventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInventory", x => new { x.BooksId, x.inventoryId });
                    table.ForeignKey(
                        name: "FK_BookInventory_books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookInventory_inventory_inventoryId",
                        column: x => x.inventoryId,
                        principalTable: "inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInventory_inventoryId",
                table: "BookInventory",
                column: "inventoryId");
        }
    }
}
