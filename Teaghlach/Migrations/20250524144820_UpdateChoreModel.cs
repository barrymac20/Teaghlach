using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teaghlach.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChoreModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chores_FamilyMembers_AssignedToId",
                table: "Chores");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToId",
                table: "Chores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_FamilyMembers_AssignedToId",
                table: "Chores",
                column: "AssignedToId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chores_FamilyMembers_AssignedToId",
                table: "Chores");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToId",
                table: "Chores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_FamilyMembers_AssignedToId",
                table: "Chores",
                column: "AssignedToId",
                principalTable: "FamilyMembers",
                principalColumn: "Id");
        }
    }
}
