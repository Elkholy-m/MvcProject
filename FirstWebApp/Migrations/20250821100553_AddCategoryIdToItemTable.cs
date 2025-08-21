﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIdToItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "items");
        }
    }
}
