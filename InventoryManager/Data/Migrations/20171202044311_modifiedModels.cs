using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManager.Data.Migrations
{
    public partial class modifiedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usage",
                table: "Items",
                newName: "TotalUsage");

            migrationBuilder.AddColumn<float>(
                name: "TempUsage",
                table: "Items",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempUsage",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "TotalUsage",
                table: "Items",
                newName: "Usage");
        }
    }
}
