using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class FixedNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26a17d98-2564-4a5c-a21d-8b806ca91db9",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mrs.", "Test" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab2c49be-9e83-41af-82b5-9165ddeb125f",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mr.", "Test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26a17d98-2564-4a5c-a21d-8b806ca91db9",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab2c49be-9e83-41af-82b5-9165ddeb125f",
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "", "" });
        }
    }
}
