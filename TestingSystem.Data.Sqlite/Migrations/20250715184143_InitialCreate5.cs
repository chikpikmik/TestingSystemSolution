using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingSystem.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsResults_Scores_ScoreId",
                table: "TestsResults");

            migrationBuilder.DropIndex(
                name: "IX_TestsResults_ScoreId",
                table: "TestsResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TestsResults_ScoreId",
                table: "TestsResults",
                column: "ScoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsResults_Scores_ScoreId",
                table: "TestsResults",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
