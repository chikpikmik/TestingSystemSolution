using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingSystem.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAnswers_TestsResults_TestResultId1",
                table: "UsersAnswers");

            migrationBuilder.DropTable(
                name: "ImageQuestion");

            migrationBuilder.RenameColumn(
                name: "TestResultId1",
                table: "UsersAnswers",
                newName: "TestResultEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAnswers_TestResultId1",
                table: "UsersAnswers",
                newName: "IX_UsersAnswers_TestResultEntityId");

            migrationBuilder.CreateTable(
                name: "ImageEntityQuestionEntity",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionEntityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEntityQuestionEntity", x => new { x.ImagesId, x.QuestionEntityId });
                    table.ForeignKey(
                        name: "FK_ImageEntityQuestionEntity_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageEntityQuestionEntity_Questions_QuestionEntityId",
                        column: x => x.QuestionEntityId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageEntityQuestionEntity_QuestionEntityId",
                table: "ImageEntityQuestionEntity",
                column: "QuestionEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAnswers_TestsResults_TestResultEntityId",
                table: "UsersAnswers",
                column: "TestResultEntityId",
                principalTable: "TestsResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAnswers_TestsResults_TestResultEntityId",
                table: "UsersAnswers");

            migrationBuilder.DropTable(
                name: "ImageEntityQuestionEntity");

            migrationBuilder.RenameColumn(
                name: "TestResultEntityId",
                table: "UsersAnswers",
                newName: "TestResultId1");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAnswers_TestResultEntityId",
                table: "UsersAnswers",
                newName: "IX_UsersAnswers_TestResultId1");

            migrationBuilder.CreateTable(
                name: "ImageQuestion",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageQuestion", x => new { x.ImagesId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ImageQuestion_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageQuestion_QuestionId",
                table: "ImageQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAnswers_TestsResults_TestResultId1",
                table: "UsersAnswers",
                column: "TestResultId1",
                principalTable: "TestsResults",
                principalColumn: "Id");
        }
    }
}
