﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teaghlach.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginFieldsToFamilyMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "FamilyMembers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "FamilyMembers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "FamilyMembers");
        }
    }
}
