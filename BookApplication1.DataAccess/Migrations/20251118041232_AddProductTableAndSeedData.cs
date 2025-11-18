using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApplication1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    EditionNum = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CreatedAt", "Date", "Description", "EditionNum", "ISBN", "Name", "Price", "Quantity", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "A. Reynolds", new DateOnly(2023, 5, 1), new DateOnly(2023, 5, 12), "A thrilling sci-fi adventure across space and time.", 2, "978-1-23456-789-7", "The Time Traveler", 499.99f, 50, 4, new DateOnly(2023, 5, 12) },
                    { 2, "Sarah Blake", new DateOnly(2022, 11, 1), new DateOnly(2022, 11, 20), "A gripping thriller filled with suspense and twists.", 1, "978-1-98765-432-1", "Mystery of the Lost Manor", 299.5f, 80, 5, new DateOnly(2022, 11, 20) },
                    { 3, "James Carter", new DateOnly(2024, 1, 1), new DateOnly(2024, 1, 10), "An epic sci-fi saga exploring distant galaxies.", 3, "978-0-12345-678-9", "Galactic Frontiers", 599f, 40, 4, new DateOnly(2024, 1, 10) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
