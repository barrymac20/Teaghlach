using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Teaghlach.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "School" },
                    { 2, "Sports" },
                    { 3, "Birthday" }
                });

            migrationBuilder.InsertData(
                table: "EventSubCategories",
                columns: new[] { "Id", "EventCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Parent-Teacher Meeting" },
                    { 2, 1, "School Play" },
                    { 3, 2, "Football" },
                    { 4, 2, "Camogie" },
                    { 5, 3, "Child's Birthday" },
                    { 6, 3, "Party" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventSubCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventSubCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventSubCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventSubCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventSubCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EventSubCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventCategories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
