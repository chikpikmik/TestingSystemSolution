using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingSystem.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AnswersOptions_AnswerOptionId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_AnswerOptionId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "AnswerOptionId",
                table: "Scores");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScoreId",
                table: "TestsResults",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScoreId",
                table: "AnswersOptions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AnswersOptions_ScoreId",
                table: "AnswersOptions",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersOptions_Scores_ScoreId",
                table: "AnswersOptions",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersOptions_Scores_ScoreId",
                table: "AnswersOptions");

            migrationBuilder.DropIndex(
                name: "IX_AnswersOptions_ScoreId",
                table: "AnswersOptions");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "AnswersOptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScoreId",
                table: "TestsResults",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "AnswerOptionId",
                table: "Scores",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_AnswerOptionId",
                table: "Scores",
                column: "AnswerOptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AnswersOptions_AnswerOptionId",
                table: "Scores",
                column: "AnswerOptionId",
                principalTable: "AnswersOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
