using Microsoft.EntityFrameworkCore.Migrations;

namespace RadicalTherapy.Migrations
{
    public partial class v2_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PayMentMethod",
                table: "RadicalReserves");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AddColumn<bool>(
                name: "UserNameType",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Mobile");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayMentMethod",
                table: "RadicalReserves",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
