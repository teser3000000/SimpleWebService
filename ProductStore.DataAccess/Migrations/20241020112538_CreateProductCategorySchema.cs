using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductCategorySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryEntityId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryEntityId",
                table: "Products",
                column: "ProductCategoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryEntityId",
                table: "Products",
                column: "ProductCategoryEntityId",
                principalTable: "ProductCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryEntityId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryEntityId",
                table: "Products");
        }
    }
}
