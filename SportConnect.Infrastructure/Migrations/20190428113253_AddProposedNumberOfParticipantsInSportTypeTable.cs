using Microsoft.EntityFrameworkCore.Migrations;

namespace SportConnect.Infrastructure.Migrations
{
    public partial class AddProposedNumberOfParticipantsInSportTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProposedNumberOfParticipants",
                table: "SportType",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposedNumberOfParticipants",
                table: "SportType");
        }
    }
}
