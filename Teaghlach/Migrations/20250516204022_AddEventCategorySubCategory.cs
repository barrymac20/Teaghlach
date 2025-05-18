using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teaghlach.Migrations
{
    /// <inheritdoc />
    public partial class AddEventCategorySubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventCategoryId",
                table: "FamilyEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventSubCategoryId",
                table: "FamilyEvents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSubCategories_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyEvents_EventCategoryId",
                table: "FamilyEvents",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyEvents_EventSubCategoryId",
                table: "FamilyEvents",
                column: "EventSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSubCategories_EventCategoryId",
                table: "EventSubCategories",
                column: "EventCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyEvents_EventCategories_EventCategoryId",
                table: "FamilyEvents",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyEvents_EventSubCategories_EventSubCategoryId",
                table: "FamilyEvents",
                column: "EventSubCategoryId",
                principalTable: "EventSubCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyEvents_EventCategories_EventCategoryId",
                table: "FamilyEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyEvents_EventSubCategories_EventSubCategoryId",
                table: "FamilyEvents");

            migrationBuilder.DropTable(
                name: "EventSubCategories");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropIndex(
                name: "IX_FamilyEvents_EventCategoryId",
                table: "FamilyEvents");

            migrationBuilder.DropIndex(
                name: "IX_FamilyEvents_EventSubCategoryId",
                table: "FamilyEvents");

            migrationBuilder.DropColumn(
                name: "EventCategoryId",
                table: "FamilyEvents");

            migrationBuilder.DropColumn(
                name: "EventSubCategoryId",
                table: "FamilyEvents");
        }
    }
}
