using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApplication1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductRenameDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Products",
                newName: "PublishedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishedDate",
                table: "Products",
                newName: "Date");
        }
    }
}
