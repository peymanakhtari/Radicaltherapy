using Microsoft.EntityFrameworkCore.Migrations;

namespace RadicalTherapy.Migrations
{
    public partial class v27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subjectId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_subjectId",
                table: "Comments",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Subjects_subjectId",
                table: "Comments",
                column: "subjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Subjects_subjectId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_subjectId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "subjectId",
                table: "Comments");
        }
    }
}
