using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApplication1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CreatedAt", "Date", "Description", "EditionNum", "ISBN", "Name", "Price", "Quantity", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, "Evelyn Hart", new DateOnly(2021, 8, 1), new DateOnly(2021, 8, 17), "A dark fantasy adventure blending magic, mythology, and mystery.", 1, "978-1-54321-987-6", "Shadows of the Forgotten Realm", 450f, 120, 5, new DateOnly(2021, 8, 17) },
                    { 5, "Dr. Neil Harmon", new DateOnly(2023, 3, 1), new DateOnly(2023, 3, 2), "A mind-bending story about alternate timelines and cosmic secrets.", 2, "978-0-24680-135-7", "The Quantum Paradox", 650f, 35, 4, new DateOnly(2023, 3, 2) },
                    { 6, "Kenji Morita", new DateOnly(2020, 12, 1), new DateOnly(2020, 12, 5), "A samurai-inspired action novel full of honor, conflict, and redemption.", 3, "978-1-67890-555-3", "Echoes of the Crimson Blade", 520.5f, 60, 4, new DateOnly(2020, 12, 5) },
                    { 7, "Maya Collins", new DateOnly(2022, 4, 1), new DateOnly(2022, 4, 14), "A slow-burn mystery unraveling eerie clues in a quiet lakeside town.", 1, "978-0-11223-445-8", "Beneath the Silver Lake", 310f, 95, 3, new DateOnly(2022, 4, 14) },
                    { 8, "L. Vargas", new DateOnly(2024, 2, 1), new DateOnly(2024, 2, 1), "A futuristic action thriller set in a war-torn cyberpunk world.", 2, "978-9-87654-320-4", "Rise of the Cyber Dominion", 799f, 20, 5, new DateOnly(2024, 2, 1) },
                    { 9, "Isabella Grant", new DateOnly(2023, 7, 1), new DateOnly(2023, 7, 22), "A historical mystery following the hunt for a forbidden ancient manuscript.", 1, "978-1-22468-975-3", "The Alchemist’s Secret Grimoire", 560.75f, 70, 4, new DateOnly(2023, 7, 22) },
                    { 10, "Theo Marquez", new DateOnly(2021, 9, 1), new DateOnly(2021, 9, 29), "A philosophical sci-fi novel exploring the human condition through space travel.", 4, "978-1-30987-642-2", "Voyage to the Edge of Nowhere", 480f, 55, 5, new DateOnly(2021, 9, 29) },
                    { 11, "Jordan Pierce", new DateOnly(2022, 2, 1), new DateOnly(2022, 2, 10), "A chilling psychological thriller set in an abandoned hospital.", 1, "978-0-33445-221-7", "The Silent Ward", 350f, 110, 3, new DateOnly(2022, 2, 10) },
                    { 12, "Ariana Vale", new DateOnly(2023, 10, 1), new DateOnly(2023, 10, 4), "An epic fantasy journey through a fallen kingdom full of secrets.", 2, "978-1-44444-222-9", "Chronicles of the Forgotten Empire", 899f, 25, 5, new DateOnly(2023, 10, 4) },
                    { 13, "Cyrus Lee", new DateOnly(2024, 3, 1), new DateOnly(2024, 3, 12), "A cyber-noir story exploring technology, identity, and rebellion.", 1, "978-2-54321-111-6", "Fragments of the Neon Sky", 420f, 75, 4, new DateOnly(2024, 3, 12) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
