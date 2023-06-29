using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Ganre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_books_Bookid",
                table: "feedbacks");

            migrationBuilder.DropTable(
                name: "compositions");

            migrationBuilder.DropTable(
                name: "fieldKnowledges");

            migrationBuilder.DropTable(
                name: "inventoryNumbers");

            migrationBuilder.DropTable(
                name: "placePublications");

            migrationBuilder.DropTable(
                name: "publishments");

            migrationBuilder.DropTable(
                name: "readers");

            migrationBuilder.RenameColumn(
                name: "Bookid",
                table: "feedbacks",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_Bookid",
                table: "feedbacks",
                newName: "IX_feedbacks_BookId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "books",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ganre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ganre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    authorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.BooksId, x.authorId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_authors_authorId",
                        column: x => x.authorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGanre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    ganresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGanre", x => new { x.BooksId, x.ganresId });
                    table.ForeignKey(
                        name: "FK_BookGanre_books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGanre_ganre_ganresId",
                        column: x => x.ganresId,
                        principalTable: "ganre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_authorId",
                table: "AuthorBook",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGanre_ganresId",
                table: "BookGanre",
                column: "ganresId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_books_BookId",
                table: "feedbacks",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_books_BookId",
                table: "feedbacks");

            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookGanre");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "ganre");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "feedbacks",
                newName: "Bookid");

            migrationBuilder.RenameIndex(
                name: "IX_feedbacks_BookId",
                table: "feedbacks",
                newName: "IX_feedbacks_Bookid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "books",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "compositions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compositions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fieldKnowledges",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fieldKnowledges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "placePublications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placePublications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publishments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "readers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    NumberTiсket = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_readers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inventoryNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    readerId = table.Column<int>(type: "int", nullable: false),
                    Date_issue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Return = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventoryNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventoryNumbers_readers_readerId",
                        column: x => x.readerId,
                        principalTable: "readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventoryNumbers_readerId",
                table: "inventoryNumbers",
                column: "readerId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_books_Bookid",
                table: "feedbacks",
                column: "Bookid",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
