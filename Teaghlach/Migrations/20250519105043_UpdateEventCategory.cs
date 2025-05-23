using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teaghlach.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyEvents_EventCategories_EventCategoryId",
                table: "FamilyEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyEvents_FamilyMembers_FamilyMemberId",
                table: "FamilyEvents");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "FamilyEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventCategoryId",
                table: "FamilyEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyEvents_EventCategories_EventCategoryId",
                table: "FamilyEvents",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyEvents_FamilyMembers_FamilyMemberId",
                table: "FamilyEvents",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyEvents_EventCategories_EventCategoryId",
                table: "FamilyEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyEvents_FamilyMembers_FamilyMemberId",
                table: "FamilyEvents");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyMemberId",
                table: "FamilyEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventCategoryId",
                table: "FamilyEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyEvents_EventCategories_EventCategoryId",
                table: "FamilyEvents",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyEvents_FamilyMembers_FamilyMemberId",
                table: "FamilyEvents",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "Id");
        }
    }
}
