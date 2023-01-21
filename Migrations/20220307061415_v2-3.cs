using Microsoft.EntityFrameworkCore.Migrations;

namespace RadicalTherapy.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegectionReason",
                table: "RadicalReserves",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegectionReason",
                table: "RadicalReserves");
        }
    }
}
