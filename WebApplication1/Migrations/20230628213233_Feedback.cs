using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bookid",
                table: "feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_Bookid",
                table: "feedbacks",
                column: "Bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_books_Bookid",
                table: "feedbacks",
                column: "Bookid",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_books_Bookid",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_Bookid",
                table: "feedbacks");

            migrationBuilder.DropColumn(
                name: "Bookid",
                table: "feedbacks");
        }
    }
}
