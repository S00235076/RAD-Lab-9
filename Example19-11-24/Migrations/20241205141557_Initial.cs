using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example19_11_24.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId1",
                table: "Students",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_StudentId1",
                table: "Students",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_StudentId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Students");
        }
    }
}
