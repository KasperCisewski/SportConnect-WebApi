using Microsoft.EntityFrameworkCore.Migrations;

namespace SportConnect.Infrastructure.Migrations
{
    public partial class AddMinimumNumberOfParticipantsAndImproveSportEventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SportEventManager",
                table: "SportEvent",
                newName: "SportEventManagerId");

            migrationBuilder.AddColumn<int>(
                name: "MinimumNumberOfParticipants",
                table: "SportEvent",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumNumberOfParticipants",
                table: "SportEvent");

            migrationBuilder.RenameColumn(
                name: "SportEventManagerId",
                table: "SportEvent",
                newName: "SportEventManager");
        }
    }
}
