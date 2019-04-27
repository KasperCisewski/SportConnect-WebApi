using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportConnect.Infrastructure.Migrations
{
    public partial class AddSkillLevelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SportEventManager",
                table: "SportEvents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "SportSkillLevelId",
                table: "SportEvents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Role",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SportSkillLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportSkillLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportEvents_SportSkillLevelId",
                table: "SportEvents",
                column: "SportSkillLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportEvents_SportSkillLevel_SportSkillLevelId",
                table: "SportEvents",
                column: "SportSkillLevelId",
                principalTable: "SportSkillLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportEvents_SportSkillLevel_SportSkillLevelId",
                table: "SportEvents");

            migrationBuilder.DropTable(
                name: "SportSkillLevel");

            migrationBuilder.DropIndex(
                name: "IX_SportEvents_SportSkillLevelId",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SportEventManager",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "SportSkillLevelId",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Role");
        }
    }
}
