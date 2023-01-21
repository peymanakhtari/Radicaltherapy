using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadicalTherapy.Migrations
{
    public partial class v25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ReseptPic",
                table: "RadicalReserves",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReseptPic",
                table: "RadicalReserves");
        }
    }
}
