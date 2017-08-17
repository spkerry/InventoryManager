using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManager.Data.Migrations
{
    public partial class ItemVendorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Vendors");

            migrationBuilder.RenameColumn(
                name: "Upc",
                table: "Vendors",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Vendors",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Vendors",
                newName: "Upc");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Vendors",
                newName: "Unit");

            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Vendors",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
