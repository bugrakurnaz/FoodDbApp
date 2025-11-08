using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDbApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateInventoryCategoryStorageConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InventoryItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "InventoryItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "InventoryItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "InventoryItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "InventoryItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "InventoryItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "InventoryItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "StorageLocationId",
                table: "InventoryItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "InventoryItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CategoryId",
                table: "InventoryItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_StorageLocationId",
                table: "InventoryItems",
                column: "StorageLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Categories_CategoryId",
                table: "InventoryItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_StorageLocations_StorageLocationId",
                table: "InventoryItems",
                column: "StorageLocationId",
                principalTable: "StorageLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Categories_CategoryId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_StorageLocations_StorageLocationId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "StorageLocations");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_CategoryId",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_StorageLocationId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "StorageLocationId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "InventoryItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InventoryItems",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
