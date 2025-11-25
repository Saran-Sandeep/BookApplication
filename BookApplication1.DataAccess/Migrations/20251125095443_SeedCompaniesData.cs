using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApplication1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompaniesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Austin", "TechNova Solutions", "512-555-2488", "73301", "TX", "4821 Innovation Way" },
                    { 2, "Seattle", "Greenfield Logistics", "206-555-8821", "98101", "WA", "1290 Harbor Drive" },
                    { 3, "Denver", "Summit Financial Group", "303-555-9034", "80202", "CO", "300 Market Street" },
                    { 4, "Phoenix", "BrightPath Health", "480-555-7645", "85004", "AZ", "950 Wellness Avenue" },
                    { 5, "San Diego", "Bluewater Media", "619-555-3377", "92101", "CA", "222 Oceanview Blvd" },
                    { 6, "Cleveland", "NorthStar Manufacturing", "216-555-7799", "44114", "OH", "784 Industrial Park Rd" },
                    { 7, "Nashville", "PrimeEdge Retail", "615-555-1200", "37201", "TN", "410 Commerce Street" },
                    { 8, "Chicago", "MetroLine Transit Systems", "312-555-9402", "60601", "IL", "515 Transit Plaza" },
                    { 9, "Portland", "Evergreen Foods", "503-555-7420", "97201", "OR", "6201 Harvest Lane" },
                    { 10, "New York", "Skyline Software Inc.", "212-555-3344", "10001", "NY", "77 Horizon Tower" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
