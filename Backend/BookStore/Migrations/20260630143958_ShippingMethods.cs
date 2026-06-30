using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class ShippingMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingMethodId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "Id", "Company", "CreatedAt", "Description", "Price", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Postnord", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pick up your parcel at a nearby pick-up point", 49m, "pick-up", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Postnord", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The parcel is delivered to your door.", 100m, "home", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Dhl", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The parcel can be picked up from a DHL service point.", 49m, "pick-up", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "instabox", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The parcel can be picked up from a Instabox parcel-box.", 49m, "box", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "budbee", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The parcel can be picked up from a Budbee parcel-box.", 49m, "box", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingMethodId",
                table: "Orders",
                column: "ShippingMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingMethods_ShippingMethodId",
                table: "Orders",
                column: "ShippingMethodId",
                principalTable: "ShippingMethods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingMethods_ShippingMethodId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingMethodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingMethodId",
                table: "Orders");
        }
    }
}
