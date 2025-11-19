using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApplication1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFKForCategoriesProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CreatedAt", "Description", "EditionNum", "ISBN", "Name", "Price", "PublishedDate", "Quantity", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "A. Reynolds", 3, new DateOnly(2023, 5, 1), "A thrilling sci-fi adventure across space and time.", 2, "978-1-23456-789-7", "The Time Traveler", 499.99f, new DateOnly(2023, 5, 12), 50, 4, new DateOnly(2023, 5, 12) },
                    { 2, "Sarah Blake", 2, new DateOnly(2022, 11, 1), "A gripping thriller filled with suspense and twists.", 1, "978-1-98765-432-1", "Mystery of the Lost Manor", 299.5f, new DateOnly(2022, 11, 20), 80, 5, new DateOnly(2022, 11, 20) },
                    { 3, "James Carter", 3, new DateOnly(2024, 1, 1), "An epic sci-fi saga exploring distant galaxies.", 3, "978-0-12345-678-9", "Galactic Frontiers", 599f, new DateOnly(2024, 1, 10), 40, 4, new DateOnly(2024, 1, 10) },
                    { 4, "Evelyn Hart", 4, new DateOnly(2021, 8, 1), "A dark fantasy adventure blending magic, mythology, and mystery.", 1, "978-1-54321-987-6", "Shadows of the Forgotten Realm", 450f, new DateOnly(2021, 8, 17), 120, 5, new DateOnly(2021, 8, 17) },
                    { 5, "Dr. Neil Harmon", 3, new DateOnly(2023, 3, 1), "A mind-bending story about alternate timelines and cosmic secrets.", 2, "978-0-24680-135-7", "The Quantum Paradox", 650f, new DateOnly(2023, 3, 2), 35, 4, new DateOnly(2023, 3, 2) },
                    { 6, "Kenji Morita", 1, new DateOnly(2020, 12, 1), "A samurai-inspired action novel full of honor, conflict, and redemption.", 3, "978-1-67890-555-3", "Echoes of the Crimson Blade", 520.5f, new DateOnly(2020, 12, 5), 60, 4, new DateOnly(2020, 12, 5) },
                    { 7, "Maya Collins", 2, new DateOnly(2022, 4, 1), "A slow-burn mystery unraveling eerie clues in a quiet lakeside town.", 1, "978-0-11223-445-8", "Beneath the Silver Lake", 310f, new DateOnly(2022, 4, 14), 95, 3, new DateOnly(2022, 4, 14) },
                    { 8, "L. Vargas", 3, new DateOnly(2024, 2, 1), "A futuristic action thriller set in a war-torn cyberpunk world.", 2, "978-9-87654-320-4", "Rise of the Cyber Dominion", 799f, new DateOnly(2024, 2, 1), 20, 5, new DateOnly(2024, 2, 1) },
                    { 9, "Isabella Grant", 7, new DateOnly(2023, 7, 1), "A historical mystery following the hunt for a forbidden ancient manuscript.", 1, "978-1-22468-975-3", "The Alchemist’s Secret Grimoire", 560.75f, new DateOnly(2023, 7, 22), 70, 4, new DateOnly(2023, 7, 22) },
                    { 10, "Theo Marquez", 3, new DateOnly(2021, 9, 1), "A philosophical sci-fi novel exploring the human condition through space travel.", 4, "978-1-30987-642-2", "Voyage to the Edge of Nowhere", 480f, new DateOnly(2021, 9, 29), 55, 5, new DateOnly(2021, 9, 29) },
                    { 11, "Jordan Pierce", 2, new DateOnly(2022, 2, 1), "A chilling psychological thriller set in an abandoned hospital.", 1, "978-0-33445-221-7", "The Silent Ward", 350f, new DateOnly(2022, 2, 10), 110, 3, new DateOnly(2022, 2, 10) },
                    { 12, "Ariana Vale", 4, new DateOnly(2023, 10, 1), "An epic fantasy journey through a fallen kingdom full of secrets.", 2, "978-1-44444-222-9", "Chronicles of the Forgotten Empire", 899f, new DateOnly(2023, 10, 4), 25, 5, new DateOnly(2023, 10, 4) },
                    { 13, "Cyrus Lee", 3, new DateOnly(2024, 3, 1), "A cyber-noir story exploring technology, identity, and rebellion.", 1, "978-2-54321-111-6", "Fragments of the Neon Sky", 420f, new DateOnly(2024, 3, 12), 75, 4, new DateOnly(2024, 3, 12) },
                    { 14, "Adrian Wells", 2, new DateOnly(2025, 11, 19), "A psychological thriller exploring the human mind.", 1, "978-1-54321-765-4-2", "The Silent Observer", 499f, new DateOnly(2018, 5, 12), 0, 4, new DateOnly(2025, 11, 19) },
                    { 15, "Laura Kim", 5, new DateOnly(2025, 11, 19), "A complete guide to mastering full-stack web frameworks and tools.", 2, "978-1-98765-123-6-1", "Modern Web Development", 899f, new DateOnly(2021, 3, 1), 0, 5, new DateOnly(2025, 11, 19) },
                    { 16, "Caleb Morgan", 6, new DateOnly(2025, 11, 19), "A journey into marine mysteries and ocean life.", 1, "978-1-33445-667-8-9", "Into the Deep Blue", 350f, new DateOnly(2015, 11, 20), 0, 3, new DateOnly(2025, 11, 19) },
                    { 17, "Meera Patel", 5, new DateOnly(2025, 11, 19), "Understanding artificial intelligence in everyday life.", 1, "978-1-22334-998-7-6", "AI for Everyone", 750f, new DateOnly(2022, 7, 10), 0, 5, new DateOnly(2025, 11, 19) },
                    { 18, "Rohan Khanna", 4, new DateOnly(2025, 11, 19), "A collection of ancient stories retold for modern readers.", 3, "978-1-55678-224-3-4", "The Forgotten Tales", 420f, new DateOnly(2010, 1, 5), 0, 4, new DateOnly(2025, 11, 19) },
                    { 19, "Sofia Bennett", 8, new DateOnly(2025, 11, 19), "Easy and delicious recipes for everyday cooking.", 1, "978-1-44223-556-5-3", "Cooking with Passion", 650f, new DateOnly(2019, 8, 18), 0, 5, new DateOnly(2025, 11, 19) },
                    { 20, "Neil Carver", 3, new DateOnly(2025, 11, 19), "A sci-fi adventure exploring distant galaxies.", 2, "978-1-99887-332-1-8", "The Stars Beyond", 580f, new DateOnly(2017, 6, 9), 0, 4, new DateOnly(2025, 11, 19) },
                    { 21, "James Holloway", 5, new DateOnly(2025, 11, 19), "A deep dive into backend development with C# and .NET Core.", 1, "978-1-11223-456-7-4", "Mastering C# and .NET", 999f, new DateOnly(2023, 2, 15), 0, 5, new DateOnly(2025, 11, 19) },
                    { 22, "Elena Rivers", 9, new DateOnly(2025, 11, 19), "How minimalism transforms lifestyle, productivity, and mindset.", 1, "978-1-77889-554-3-7", "The Art of Minimalism", 320f, new DateOnly(2016, 9, 27), 0, 4, new DateOnly(2025, 11, 19) },
                    { 23, "Dr. Nathan Clarke", 7, new DateOnly(2025, 11, 19), "From Mesopotamia to Rome – a detailed historical exploration.", 2, "978-1-66554-778-2-9", "History of Ancient Civilizations", 850f, new DateOnly(2012, 4, 30), 0, 5, new DateOnly(2025, 11, 19) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");
        }
    }
}
