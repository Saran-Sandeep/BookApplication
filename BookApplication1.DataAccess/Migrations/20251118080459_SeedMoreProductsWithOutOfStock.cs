using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApplication1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProductsWithOutOfStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CreatedAt", "Description", "EditionNum", "ISBN", "Name", "Price", "PublishedDate", "Quantity", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 14, "Adrian Wells", new DateOnly(2025, 11, 18), "A psychological thriller exploring the human mind.", 1, "978-1-54321-765-4-2", "The Silent Observer", 499f, new DateOnly(2018, 5, 12), 0, 4, new DateOnly(2025, 11, 18) },
                    { 15, "Laura Kim", new DateOnly(2025, 11, 18), "A complete guide to mastering full-stack web frameworks and tools.", 2, "978-1-98765-123-6-1", "Modern Web Development", 899f, new DateOnly(2021, 3, 1), 0, 5, new DateOnly(2025, 11, 18) },
                    { 16, "Caleb Morgan", new DateOnly(2025, 11, 18), "A journey into marine mysteries and ocean life.", 1, "978-1-33445-667-8-9", "Into the Deep Blue", 350f, new DateOnly(2015, 11, 20), 0, 3, new DateOnly(2025, 11, 18) },
                    { 17, "Meera Patel", new DateOnly(2025, 11, 18), "Understanding artificial intelligence in everyday life.", 1, "978-1-22334-998-7-6", "AI for Everyone", 750f, new DateOnly(2022, 7, 10), 0, 5, new DateOnly(2025, 11, 18) },
                    { 18, "Rohan Khanna", new DateOnly(2025, 11, 18), "A collection of ancient stories retold for modern readers.", 3, "978-1-55678-224-3-4", "The Forgotten Tales", 420f, new DateOnly(2010, 1, 5), 0, 4, new DateOnly(2025, 11, 18) },
                    { 19, "Sofia Bennett", new DateOnly(2025, 11, 18), "Easy and delicious recipes for everyday cooking.", 1, "978-1-44223-556-5-3", "Cooking with Passion", 650f, new DateOnly(2019, 8, 18), 0, 5, new DateOnly(2025, 11, 18) },
                    { 20, "Neil Carver", new DateOnly(2025, 11, 18), "A sci-fi adventure exploring distant galaxies.", 2, "978-1-99887-332-1-8", "The Stars Beyond", 580f, new DateOnly(2017, 6, 9), 0, 4, new DateOnly(2025, 11, 18) },
                    { 21, "James Holloway", new DateOnly(2025, 11, 18), "A deep dive into backend development with C# and .NET Core.", 1, "978-1-11223-456-7-4", "Mastering C# and .NET", 999f, new DateOnly(2023, 2, 15), 0, 5, new DateOnly(2025, 11, 18) },
                    { 22, "Elena Rivers", new DateOnly(2025, 11, 18), "How minimalism transforms lifestyle, productivity, and mindset.", 1, "978-1-77889-554-3-7", "The Art of Minimalism", 320f, new DateOnly(2016, 9, 27), 0, 4, new DateOnly(2025, 11, 18) },
                    { 23, "Dr. Nathan Clarke", new DateOnly(2025, 11, 18), "From Mesopotamia to Rome – a detailed historical exploration.", 2, "978-1-66554-778-2-9", "History of Ancient Civilizations", 850f, new DateOnly(2012, 4, 30), 0, 5, new DateOnly(2025, 11, 18) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);
        }
    }
}
