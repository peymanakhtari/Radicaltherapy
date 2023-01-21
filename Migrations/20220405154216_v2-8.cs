using Microsoft.EntityFrameworkCore.Migrations;

namespace RadicalTherapy.Migrations
{
    public partial class v28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Reserve",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    q1 = table.Column<int>(type: "int", nullable: false),
                    q2 = table.Column<int>(type: "int", nullable: false),
                    q3 = table.Column<int>(type: "int", nullable: false),
                    q4 = table.Column<int>(type: "int", nullable: false),
                    q5 = table.Column<int>(type: "int", nullable: false),
                    q6 = table.Column<int>(type: "int", nullable: false),
                    q7 = table.Column<int>(type: "int", nullable: false),
                    q8 = table.Column<int>(type: "int", nullable: false),
                    q9 = table.Column<int>(type: "int", nullable: false),
                    q10 = table.Column<int>(type: "int", nullable: false),
                    q11 = table.Column<int>(type: "int", nullable: false),
                    q12 = table.Column<int>(type: "int", nullable: false),
                    q13 = table.Column<int>(type: "int", nullable: false),
                    q14 = table.Column<int>(type: "int", nullable: false),
                    q15 = table.Column<int>(type: "int", nullable: false),
                    q16 = table.Column<int>(type: "int", nullable: false),
                    q17 = table.Column<int>(type: "int", nullable: false),
                    q18 = table.Column<int>(type: "int", nullable: false),
                    q19 = table.Column<int>(type: "int", nullable: false),
                    q20 = table.Column<int>(type: "int", nullable: false),
                    q21 = table.Column<int>(type: "int", nullable: false),
                    q22 = table.Column<int>(type: "int", nullable: false),
                    q23 = table.Column<int>(type: "int", nullable: false),
                    q24 = table.Column<int>(type: "int", nullable: false),
                    q25 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Reserve");
        }
    }
}
