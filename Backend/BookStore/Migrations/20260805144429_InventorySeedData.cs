using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class InventorySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "AmountInStock", "BookId", "CreatedAt", "ReorderThreshold", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, 25, 2, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 3, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 18, 4, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 9, 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 0, 6, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 43, 7, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 9, 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 48, 9, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 28, 11, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, 12, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 0, 13, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 27, 14, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 42, 15, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 16, 16, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 36, 17, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 17, 18, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 0, 19, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 22, 20, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 28, 21, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 21, 22, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 25, 23, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 17, 24, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 42, 25, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 37, 26, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 48, 27, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 7, 28, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 22, 29, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 36, 30, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 3, 31, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 4, 32, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 42, 33, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 0, 34, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 9, 35, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 7, 36, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 34, 37, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 4, 38, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 0, 39, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 18, 40, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 15, 41, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 42, 42, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 13, 43, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 42, 44, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 34, 45, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 0, 46, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 3, 47, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 40, 48, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 32, 49, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 25, 50, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 1, 51, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 12, 52, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 0, 53, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 26, 54, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 0, 55, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 39, 56, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 21, 57, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 0, 58, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 24, 59, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 40, 60, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 25, 61, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 34, 62, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 41, 63, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 0, 64, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 0, 65, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 45, 66, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 1, 67, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 3, 68, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 0, 69, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 2, 70, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 49, 71, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 38, 72, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 14, 73, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 0, 74, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 40, 75, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 14, 76, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 0, 77, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 2, 78, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 8, 79, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 0, 80, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 1, 81, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 19, 82, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 0, 83, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 23, 84, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 4, 85, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 1, 86, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 4, 87, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 3, 88, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 48, 89, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 20, 90, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 1, 91, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 16, 92, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 11, 93, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 46, 94, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 2, 95, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 12, 96, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 33, 97, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 0, 98, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 1, 99, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 48, 100, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 27, 101, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 6, 102, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 2, 103, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 40, 104, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 1, 105, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 19, 106, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 0, 107, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 30, 108, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 31, 109, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 7, 110, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 44, 111, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 0, 112, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 112);
        }
    }
}
