using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_inventory_TicketId",
                table: "inventory",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInventory");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "ticket");
        }
    }
}
