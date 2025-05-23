using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teaghlach.Migrations
{
    /// <inheritdoc />
    public partial class AddChoreTypeToChore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Chores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Chores");
        }
    }
}
