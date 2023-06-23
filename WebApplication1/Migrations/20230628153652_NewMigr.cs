using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class NewMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookFeedback");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookFeedback",
                columns: table => new
                {
                    Booksid = table.Column<int>(type: "int", nullable: false),
                    FeedbacksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFeedback", x => new { x.Booksid, x.FeedbacksId });
                    table.ForeignKey(
                        name: "FK_BookFeedback_books_Booksid",
                        column: x => x.Booksid,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookFeedback_feedbacks_FeedbacksId",
                        column: x => x.FeedbacksId,
                        principalTable: "feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookFeedback_FeedbacksId",
                table: "BookFeedback",
                column: "FeedbacksId");
        }
    }
}
