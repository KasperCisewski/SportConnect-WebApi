using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportConnect.Infrastructure.Migrations
{
    public partial class AddLogRecordHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogRecordDate",
                table: "UserLogRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LogRecordDate",
                table: "UserLogRecords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
