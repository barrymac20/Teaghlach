﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Teaghlach.Migrations
{
    /// <inheritdoc />
    public partial class AddFamilyRoleAndSeedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FamilyRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Parent" },
                    { 2, "Child" }
                });

            migrationBuilder.InsertData(
                table: "FamilySubRoles",
                columns: new[] { "Id", "FamilyRoleId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Father" },
                    { 2, 1, "Mother" },
                    { 3, 2, "Son" },
                    { 4, 2, "Daughter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FamilySubRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FamilySubRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FamilySubRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FamilySubRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FamilyRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FamilyRoles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
